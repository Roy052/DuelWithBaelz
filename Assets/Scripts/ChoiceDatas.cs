using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ChoiceType
{
    Sum = 0,
    Multiple = 1,
    Rat = 2,
}

public class ChoiceDatas : Singleton
{
    public List<ChoiceType> types = new List<ChoiceType>();
    public List<int> values = new List<int>();

    List<(ChoiceType, int)> currentChoices = new List<(ChoiceType, int)>();
    List<int> currentChoiceIdxes = new List<int>();
    int currentIdx = -1;

    private void Awake()
    {
        if (choiceDatas == null)
            choiceDatas = this;
        else
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        choiceDatas = null;
    }

    public void Set()
    {
        int minValue = 2;
        currentIdx = -1;
        types.Clear();
        values.Clear();

        for(int i = minValue; i < 51; i++)
        {
            if (i % 5 == 0)
            {
                types.Add(ChoiceType.Rat);
                values.Add(i / 5);
                types.Add(ChoiceType.Sum);
                values.Add(i);
            }
            else
            {
                types.Add(ChoiceType.Sum);
                values.Add(i);
            }
        }
    }

    public List<(ChoiceType, int)> PickChoices()
    {
        int leftAmmount = Math.Min(values.Count - currentIdx - 1, 5);
        int pickAmmount = Math.Min(leftAmmount, 3);

        int count = 0;
        bool[] isSelected = new bool[leftAmmount];
        while (count < pickAmmount)
        {
            int tempIdx = UnityEngine.Random.Range(0, leftAmmount);
            if (isSelected[tempIdx])
                continue;
            isSelected[tempIdx] = true;
            count++;
        }

        currentChoiceIdxes.Clear();
        currentChoices.Clear();
        for (int i = 0; i < leftAmmount; i++)
        {
            if (isSelected[i])
            {
                currentChoiceIdxes.Add(currentIdx + 1 + i);
                currentChoices.Add((types[currentIdx + 1 + i], values[currentIdx + 1 + i]));
            }
        }

        return currentChoices;
    }

    public void SetCurrentIdx(int idx)
    {
        currentIdx = currentChoiceIdxes[idx];
    }

    public (ChoiceType, int) GetCurrentChoiceData()
    {
        if (currentIdx >= types.Count)
            return (ChoiceType.Sum, -1);
        return (types[currentIdx], values[currentIdx]);
    }

    public (ChoiceType, int) GetChoiceData(int idx)
    {
        if (idx >= types.Count)
            return (ChoiceType.Sum, -1);
        return (types[idx], values[idx]);
    }

    public List<(ChoiceType, int)> GetPickChoiceDatas()
    {
        return currentChoices;
    }

    public void ResetCurrentIdx(int diceCount)
    {
        currentIdx = values.FindIndex(x => x >= diceCount) - 1;
    }
}
