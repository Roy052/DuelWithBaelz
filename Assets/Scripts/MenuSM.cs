using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSM : Singleton
{
    public GameObject objMode;
    public GameObject objOption;
    public Image imgPortrait;

    public Text textPlay;
    public Text textMode;
    public Text textOption;

    void Start()
    {
        imgPortrait.sprite = imageManager.portraitSprites[Random.Range(0, imageManager.portraitSprites.Length)];
        Observer.changeLang += ChangeLang;
        ChangeLang();
    }

    private void OnDestroy()
    {
        Observer.changeLang -= ChangeLang;
    }

    public void OnclickPlay()
    {
        gameManager.mode = GameMode.None;
        gameManager.LoadScene("Duel");
    }

    public void OnClickMode()
    {
        objMode.SetActive(true);
    }

    public void OnClickOptions()
    {
        objOption.SetActive(true);
    }

    public void ChangeLang()
    {
        textPlay.text = Texts.menuLabels[0, (int)OptionList.languageType];
        textMode.text = Texts.menuLabels[1, (int)OptionList.languageType];
        textOption.text = Texts.menuLabels[2, (int)OptionList.languageType];
    }
}
