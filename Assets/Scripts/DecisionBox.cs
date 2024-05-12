using UnityEngine;
using UnityEngine.UI;

public class DecisionBox : Singleton
{
    public Choice currentChoice;
    public GameObject objChallenge;
    public GameObject objPass;

    public Text textChallenge;
    public Text textPass;

    public void Show()
    {
        var data = choiceDatas.GetCurrentChoiceData();
        currentChoice.Set(data.Item1, data.Item2);
        textChallenge.text = Texts.decisionLabels[0, (int)OptionList.languageType];
        textPass.text = Texts.decisionLabels[1, (int)OptionList.languageType];
        this.SetActive(true);
    }

    public void Hide()
    {
        this.SetActive(false);
    }

    public void OnChallenge()
    {
        duelSM.isChallengeStarted = true;
        duelSM.isCurrentJobEnded = true;
    }

    public void OnAccept()
    {
        duelSM.isCurrentJobEnded = true;
    }
}
