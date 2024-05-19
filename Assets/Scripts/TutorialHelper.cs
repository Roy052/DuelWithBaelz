using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TutorialProcess
{
    StartTutorial = 0,
    RollDice = 1,
    BeforeShowChoiceCard = 2,
    AfterShowChoiceCard = 3,
    BeforeShowDecision = 4,
    AfterShowDecision = 5,
    InJudge = 6,
    UsingItem = 7,
    EndTutorial = 8,
}

public class TutorialHelper : MonoBehaviour
{
    public Image shadow;
    public GameObject objDesc;
    public Text desc;
    public static AudioSource typingSound;

    Dictionary<int, Transform> originalParents = new Dictionary<int, Transform>();
    Dictionary<int, GameObject> gameObjects = new Dictionary<int, GameObject>();

    static int currentId = 0;
    static WaitForSeconds delay = new WaitForSeconds(0.1f);

    private void Awake()
    {
        typingSound = GetComponent<AudioSource>();
    }

    public static IEnumerator Typing(Text desc, string str)
    {
        typingSound.Play();
        desc.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            desc.text += str[i];
            yield return delay;
        }
        typingSound.Stop();
    }

    public IEnumerator ShowTutorial(int num)
    {
        shadow.SetActive(true);
        objDesc.SetActive(true);

        for(int i = 0; i < 4; i++)
        {
            if (string.IsNullOrEmpty(Texts.TutorialTexts[(int)OptionList.languageType, num, i]))
                break;

            yield return Typing(desc, Texts.TutorialTexts[(int)OptionList.languageType, num, i]);
            yield return Utilities.WaitForOneSecond;
        }
        shadow.SetActive(false);
        objDesc.SetActive(false);
    }

    public int TransferObject(GameObject obj)
    {
        currentId++;
        originalParents.Add(currentId, obj.transform.parent);
        gameObjects.Add(currentId, obj);
        return currentId;
    }

    public void ReturnObject(int id)
    {
        gameObjects[id].transform.SetParent(originalParents[id]);
        gameObjects.Remove(id);
        originalParents.Remove(id);
    }

    public void ReturnAllObject()
    {
        List<int> ids = new List<int>(originalParents.Keys);

        while(ids.Count > 0)
        {
            ReturnObject(ids[0]);
            ids.RemoveAt(0);
        }
    }
}
