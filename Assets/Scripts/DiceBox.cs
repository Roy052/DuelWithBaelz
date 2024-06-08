using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBox : MonoBehaviour
{
    public GameObject shadow;
    public Dice[] dices;
    public int diceCount = 0;

    int[] diceValues = new int[5];

    public void Set()
    {
        if (shadow)
            shadow.SetActive(true);
        for (int i = 0; i < diceCount; i++)
        {
            diceValues[i] = Random.Range(1, 7);
            dices[i].Roll(diceValues[i], i);
            dices[i].SetActive(true);
            dices[i].funcClick = (idx) => 
            {
                StartCoroutine(_Reroll(idx));
            };
            dices[i].btn.enabled = false;
        }

        for (int i = diceCount; i < dices.Length; i++)
            dices[i].SetActive(false);
    }

    public int GetValueSum()
    {
        int sum = 0;
        for(int i = 0; i < diceCount; i++)
        {
            if (diceValues[i] == 6) continue;
            sum += diceValues[i];
        }
        return sum;
    }

    public static int GetValueSum(List<int> diceList)
    {
        int sum = 0;
        for (int i = 0; i < diceList.Count; i++)
        {
            if (diceList[i] == 6) continue;
            sum += diceList[i];
        }
        return sum;
    }
    
    public int GetRatCount()
    {
        int count = 0;
        for (int i = 0; i < diceCount; i++)
        {
            if (diceValues[i] == 6)
                count++;
        }
        return count;
    }

    public static int GetRatCount(List<int> diceList)
    {
        int count = 0;
        for (int i = 0; i < diceList.Count; i++)
        {
            if (diceList[i] == 6)
                count++;
        }
        return count;
    }

    public IEnumerator ShowOneByOne()
    {
        if (shadow)
            shadow.SetActive(false);
        for (int i = 0; i < dices.Length; i++)
            dices[i].SetActive(false);

        yield return Utilities.WaitForHalfSecond;
        for(int i = 0; i < diceCount; i++)
        {
            dices[i].SetActive(true);
            yield return Utilities.WaitForHalfSecond;
        }
    }

    public int GetValue(int idx)
    {
        if (diceCount <= idx)
            return 0;

        return diceValues[idx];
    }

    public void AddDice(int count, bool currentActive)
    {
        int current = diceCount;
        diceCount += count;

        if (currentActive)
        {
            for (int i = current; i < diceCount; i++)
            {
                diceValues[i] = Random.Range(1, 7);
                dices[i].Roll(diceValues[i], i);
                dices[i].SetActive(true);
                dices[i].funcClick = (idx) =>
                {
                    StartCoroutine(_Reroll(idx));
                };
                dices[i].btn.enabled = false;
            }
        }
    }

    public void Reroll(int idx)
    {
        dices[idx].Roll(Random.Range(1, 7), idx);
    }

    IEnumerator _Reroll(int idx)
    {
        Singleton.audioManager.PlaySFX(AudioManager.SFX.DiceRoll);
        yield return new WaitForSeconds(2f);
        Reroll(idx);
        Singleton.duelSM.isSelectDiceEnded = true;
    }

    public void SetDiceClickable()
    {
        for (int i = 0; i < diceCount; i++)
            dices[i].btn.enabled = true;
    }

    public void SetDiceUnClickable()
    {
        for (int i = 0; i < diceCount; i++)
            dices[i].btn.enabled = false;
    }
}
