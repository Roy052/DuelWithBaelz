using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static GameManager gameManager;
    public static ImageManager imageManager = null;
    public static DuelSM duelSM = null;
    public static ChoiceDatas choiceDatas = null;
    public static AudioManager audioManager = null;
    public static OptionList optionList = null;
}
