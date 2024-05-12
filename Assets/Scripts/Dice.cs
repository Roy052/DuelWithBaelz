using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Image imgDice;
    public int num;
    public void Roll(int num)
    {
        this.num = num;
        imgDice.sprite = Singleton.imageManager.sideSprites[num - 1];
    }
}
