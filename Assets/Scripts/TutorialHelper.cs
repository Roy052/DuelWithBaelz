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
    public Image[] imgCharacters;
    public Material matGreyScale;

    public Image shadow;
    public GameObject objDesc;
    public Text textSpeaker;
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

    CharacterType beforeChar = CharacterType.None;
    public void ShowImage(CharacterType type)
    {
        imgCharacters[(int)type].SetActive(true);
        imgCharacters[(int)type].material = null;
        if (beforeChar != CharacterType.None)
            imgCharacters[(int)beforeChar].material = matGreyScale;
        
        if(type > CharacterType.Me)
        {
            for(int i = (int)CharacterType.Hayko; i < (int)CharacterType.Max; i++)
                if (i != (int)type)
                    imgCharacters[i].SetActive(false);
        }
        beforeChar = type;
    }

    public void GoNext()
    {
        goNext++;
    }

    static int goNext = -1;
    public static IEnumerator Typing(Text desc, string str)
    {
        goNext = -1;
        typingSound.Play();
        desc.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            if(goNext == 0)
            {
                desc.text = str;
                break;
            }

            desc.text += str[i];
            yield return delay;
        }
        typingSound.Stop();
    }

    public IEnumerator ShowTutorial(int num)
    {
        List<Tutorial> tutorialList = new List<Tutorial>();
        foreach(Tutorial item in Tutorials.tutorials)
        {
            if (item.id == num)
                tutorialList.Add(item);
        }

        for(int i = 0; i < tutorialList.Count; i++)
        {
            switch (tutorialList[i].tutorialType)
            {
                case TutorialType.Dialog:
                    shadow.SetActive(true);
                    objDesc.SetActive(true);
                    textSpeaker.SetActive(true);
                    ShowImage(tutorialList[i].characterType);
                    textSpeaker.text = Texts.dialogCharacterNames[(int)tutorialList[i].characterType, (int)OptionList.languageType];
                    yield return Typing(desc, tutorialList[i].Dialog[(int)OptionList.languageType]);
                    goNext = 0;
                    yield return new WaitUntil(() => goNext == 1);
                    break;
                case TutorialType.Button:
                    shadow.SetActive(false);
                    objDesc.SetActive(false);
                    goNext = 0;
                    yield return new WaitUntil(() => goNext == 1);
                    break;
                case TutorialType.SelectCard:
                    shadow.SetActive(false);
                    objDesc.SetActive(false);
                    goNext = 0;
                    yield return new WaitUntil(() => goNext == 1);
                    break;
                case TutorialType.SelectDecision:
                    shadow.SetActive(false);
                    objDesc.SetActive(false);
                    goNext = 0;
                    yield return new WaitUntil(() => goNext == 1);
                    break;
            }
        }

        for (int i = 0; i < imgCharacters.Length; i++)
            imgCharacters[i].SetActive(false);
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
