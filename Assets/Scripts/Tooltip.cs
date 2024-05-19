using UnityEngine;
using UnityEngine.UI;

public class Tooltip : Singleton
{
    public RectTransform rect;
    public Text textName;
    public Text textDesc;

    public void Show()
    {
        this.SetActive(true);
    }

    public void Hide()
    {
        this.SetActive(false);
    }

    public void Setitem(ItemType type)
    {
        textName.text = Texts.itemNames[(int)type, (int)OptionList.languageType];
        textDesc.text = Texts.itemDescs[(int)type, (int)OptionList.languageType];
    }
}
