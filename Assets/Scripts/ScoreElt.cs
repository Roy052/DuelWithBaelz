using UnityEngine;
using UnityEngine.UI;

public class ScoreElt : MonoBehaviour
{
    public Text textDesc;
    public Text textValue;

    public void Set(string desc, int value)
    {
        textDesc.text = desc;
        textValue.text = $"+ {value}";
    }
}
