using UnityEngine.UI;

public class ModeList : Singleton
{
    public Text labelTitle;
    public Text[] labelModes;

    private void Awake()
    {
        Observer.changeLang += RefreshUI;
        RefreshUI();
    }

    void RefreshUI()
    {
        labelTitle.text = Texts.menuLabels[1, (int)OptionList.languageType];
        for(int i = 0; i < labelModes.Length; i++)
            labelModes[i].text = Texts.modeLabels[i, (int)OptionList.languageType];
    }

    public void PlayLoseDouble()
    {
        gameManager.mode = GameMode.LoseDouble;
        gameManager.LoadScene("Duel");
    }

    public void PlayOneDiceMode()
    {
        gameManager.mode = GameMode.OneDice;
        gameManager.LoadScene("Duel");
    }

    public void Close()
    {
        this.SetActive(false);
    }
}
