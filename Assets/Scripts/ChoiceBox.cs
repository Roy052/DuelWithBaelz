public class ChoiceBox : Singleton
{
    public Choice[] choices;

    public void Start()
    {
        foreach(Choice choice in choices)
        {
            choice.SetActive(false);
            choice.funcClick = Choice;
        }
    }

    public void Show()
    {
        var datas = choiceDatas.PickChoices();
        for(int i = 0; i < datas.Count; i++)
        {
            choices[i].Set(datas[i].Item1, datas[i].Item2);
            choices[i].SetActive(true);
        }

        for (int i = datas.Count; i < 3; i++)
            choices[i].SetActive(false);
    }

    public void Hide()
    {
        foreach (Choice choice in choices)
            choice.SetActive(false);
    }

    public void Choice(int num)
    {
        choiceDatas.SetCurrentIdx(num);
        duelSM.isCurrentJobEnded = true;
        Hide();
    }
}
