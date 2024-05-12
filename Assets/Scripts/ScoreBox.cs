using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreBox : Singleton
{
    public GameObject scoreElt;

    public Text textLabel;
    public Text textScoreSum;

    List<ScoreElt> eltList = new List<ScoreElt>();

    public IEnumerator Show()
    {
        foreach (var elt in eltList)
            elt.SetActive(false);

        this.SetActive(true);

        int scoreSum = 0;
        GameResult result = duelSM.gameResult;

        scoreSum += result.isClear ? 1000 : 0;
        if(eltList.Count < 1)
        {
            GameObject temp = Instantiate(scoreElt, scoreElt.transform.parent);
            eltList.Add(temp.GetComponent<ScoreElt>());
        }
        eltList[0].Set(Texts.scoreDesc[(int)OptionList.languageType, 0], result.isClear ? 1000 : 0);
        eltList[0].SetActive(true);

        yield return Utilities.WaitForOneSecond;

        scoreSum += result.isClear ? 500 : (result.currentRound - 1) * 100;
        if (eltList.Count < 2)
        {
            GameObject temp = Instantiate(scoreElt, scoreElt.transform.parent);
            eltList.Add(temp.GetComponent<ScoreElt>());
        }
        eltList[1].Set(Texts.scoreDesc[(int)OptionList.languageType, 1], result.isClear ? 500 : (result.currentRound - 1) * 100);
        eltList[1].SetActive(true);

        yield return Utilities.WaitForOneSecond;

        int diceSum = result.currentRound * (result.currentRound + 1) / 2;
        scoreSum += (diceSum - result.loseDices) * 10;
        if (eltList.Count < 3)
        {
            GameObject temp = Instantiate(scoreElt, scoreElt.transform.parent);
            eltList.Add(temp.GetComponent<ScoreElt>());
        }
        eltList[2].Set(Texts.scoreDesc[(int)OptionList.languageType, 2], (diceSum - result.loseDices) * 10);
        eltList[2].SetActive(true);

        yield return Utilities.WaitForOneSecond;

        int time = DateTime.Now.Second - result.startTime.Second;
        time = Math.Max(0, Math.Min(99, (600 - time) / 10));
        scoreSum += time;
        if (eltList.Count < 4)
        {
            GameObject temp = Instantiate(scoreElt, scoreElt.transform.parent);
            eltList.Add(temp.GetComponent<ScoreElt>());
        }
        eltList[3].GetComponent<ScoreElt>().Set(Texts.scoreDesc[(int)OptionList.languageType, 3], time);
        eltList[3].SetActive(true);

        yield return Utilities.WaitForOneSecond;

        textLabel.text = OptionList.languageType == LanguageType.English ? "Result" : "°á°ú";
        textScoreSum.text = scoreSum.ToString();
    }
}
