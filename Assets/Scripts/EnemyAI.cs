using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Singleton
{
    public float MistakeValue = 0.15f;

    Dictionary<(int, int), float> probSumValues = new Dictionary<(int, int), float>();
    Dictionary<(int, int), float> probRatValues = new Dictionary<(int, int), float>();
    List<float> notExistProbValues = new List<float>() { 1 };
    List<float> existProbValues = new List<float>() { 1 };

    public float CalculateProbabilitySum(int diceAmmount, int sum)
    {
        if (sum < 0)
            return 1;

        if (probSumValues.ContainsKey((diceAmmount, sum)))
            return probSumValues[(diceAmmount, sum)] + Random.Range(-MistakeValue, MistakeValue);

        int minValue = diceAmmount;
        int averageValue = diceAmmount * 3;
        int maxValue = diceAmmount * 5;

        float lineWidth = Mathf.Min(averageValue - minValue, maxValue - sum) / (float)(maxValue - averageValue);
        float prob = lineWidth * lineWidth * 0.5f;

        if (sum < averageValue)
        {
            lineWidth = (sum - minValue) / (float)(averageValue - minValue);
            prob += 0.5f - (lineWidth * lineWidth * 0.5f);
        }

        Debug.Log($"P({sum},{diceAmmount}) = {prob}");

        probSumValues.Add((diceAmmount, sum), prob);

        prob += Random.Range(-MistakeValue, MistakeValue);

        return prob;
    }

    public float CalculateProbabilityRat(int diceAmmount, int ratAmmount)
    {
        if (ratAmmount > diceAmmount)
            return 0;

        if (probRatValues.ContainsKey((diceAmmount, ratAmmount)))
            return 1 - probRatValues[(diceAmmount, ratAmmount)];

        float prob = 0;
        for(int i = 0; i < ratAmmount; i++)
        {
            if (probRatValues.ContainsKey((diceAmmount, i)))
            {
                prob += probRatValues[(diceAmmount, i)];
                continue;
            }

            if (notExistProbValues.Count <= diceAmmount - i)
            {
                while (notExistProbValues.Count <= diceAmmount - i)
                    notExistProbValues.Add(notExistProbValues[notExistProbValues.Count - 1] * 5 / 6f);
            }

            if(existProbValues.Count <= i)
            {
                while (existProbValues.Count <= i)
                    existProbValues.Add(existProbValues[existProbValues.Count - 1] * 1 / 6f);
            }

            int upSum = 1;
            int downSum = 1;

            for (int j = 0; i < i - 1; i++)
            {
                upSum *= diceAmmount - j;
                downSum *= j + 1;
            }

            prob += (upSum / (float)downSum) * notExistProbValues[diceAmmount - i] * existProbValues[i];
        }

        probRatValues[(diceAmmount, ratAmmount)] = prob;

        prob += Random.Range(-MistakeValue, MistakeValue);

        return 1 - prob;
    }

    public void Decide()
    {
        var data = choiceDatas.GetCurrentChoiceData();
        float randValue = 0;
        int diceAmmount;
        switch (data.Item1)
        {
            case ChoiceType.Sum:
                int sum = data.Item2 - duelSM.enemyDiceBox.GetValueSum();
                diceAmmount = duelSM.myDiceBox.diceCount;
                randValue = CalculateProbabilitySum(diceAmmount, sum);
                break;
            case ChoiceType.Multiple:
                break;
            case ChoiceType.Rat:
                int ratAmmount = data.Item2 - duelSM.enemyDiceBox.GetRatCount();
                diceAmmount = duelSM.myDiceBox.diceCount;
                randValue = CalculateProbabilityRat(diceAmmount, ratAmmount);
                break;
        }

        float tempValue = Random.Range(0, 1f);
        duelSM.isChallengeStarted = true;
        if (randValue >= tempValue) 
            duelSM.isChallengeStarted = false;

        Debug.Log($"{randValue}, {tempValue}");

        StartCoroutine(WaitForEnd());
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(2);
        duelSM.isCurrentJobEnded = true;
    }

    public void Choose()
    {
        StartCoroutine(WaitForChoose());
    }

    IEnumerator WaitForChoose()
    {
        
        yield return new WaitForSeconds(2);
        duelSM.choiceBox.Show();
        List<float> probList = new List<float>();
        var list = choiceDatas.GetPickChoiceDatas();
        int diceAmmount;
        foreach (var data in list)
        {
            switch (data.Item1)
            {
                case ChoiceType.Sum:
                    int sum = data.Item2 - duelSM.enemyDiceBox.GetValueSum();
                    diceAmmount = duelSM.myDiceBox.diceCount;
                    probList.Add(CalculateProbabilitySum(diceAmmount, sum));
                    break;
                case ChoiceType.Multiple:
                    break;
                case ChoiceType.Rat:
                    int ratAmmount = data.Item2 - duelSM.enemyDiceBox.GetRatCount();
                    diceAmmount = duelSM.myDiceBox.diceCount;
                    probList.Add(CalculateProbabilityRat(diceAmmount, ratAmmount));
                    break;
            }
        }

        int maxIdx = 0;
        if (probList.Count > 1)
        {
            for (int i = 1; i < probList.Count; i++)
                if (probList[i] > probList[maxIdx])
                    maxIdx = i;
        }

        duelSM.choiceBox.Choice(maxIdx);
    }
}