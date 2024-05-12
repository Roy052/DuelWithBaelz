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
        for(int i = 0; i < diceCount; i++)
        {
            diceValues[i] = Random.Range(1, 7);
            dices[i].Roll(diceValues[i]);
            dices[i].SetActive(true);
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
}
