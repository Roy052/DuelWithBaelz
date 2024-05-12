using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Choice : Singleton
{
    public int num;

    public Image imgType;
    public Text textValue;
    public Text textDesc;

    public UnityAction<int> funcClick;

    public void Set(ChoiceType type, int value)
    {
        imgType.sprite = imageManager.typeSprites[(int)type];
        textValue.text = value.ToString();
        textDesc.text = $"{Texts.ChoiceDesc[(int)type, (int)OptionList.languageType]}{value}{Texts.ChoiceTail[(int)OptionList.languageType]}";
    }

    public void OnClickChoice()
    {
        funcClick?.Invoke(num);
    }
}
