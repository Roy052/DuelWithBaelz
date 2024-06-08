using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Image imgDice;
    public int num;
    public Button btn;
    public UnityAction<int> funcClick = null;

    int idx = -1;

    public void Roll(int num, int idx)
    {
        this.num = num;
        this.idx = idx;
        imgDice.sprite = Singleton.imageManager.sideSprites[num - 1];
    }

    public void OnClick()
    {
        if (idx == -1)
            return;

        funcClick?.Invoke(idx);
    }
}
