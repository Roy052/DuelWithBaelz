using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameResult
{
    public System.DateTime startTime;
    public bool isClear;
    public int currentRound;
    public int loseDices;
    public int duration;
}

public enum GameState
{
    BeforeStart = 0,
    SetDiceNum = 1,
    GetItem = 2,
    InChoice = 3,
    InDecision = 4,
    BaelzThinking = 5,
    InJudge = 6,
    ChangingDice = 7,
    SelectDice = 8,
}

public class DuelSM : Singleton
{
    const string TutorialKey = "DuelWithBaelz_IsTutorialPlayed";
    const float ScoreBoxOriginX = 0;
    const float ScoreBoxAfterX = -710f;

    enum ChallengeResult
    {
        Success = 0,
        Failed = 1,
    }

    public GameState gameState = GameState.BeforeStart;

    public Text textRoundBig;
    public Text textRound;

    public ChoiceDatas conditionDatas;

    public DiceBox enemyDiceBox;
    public DiceBox myDiceBox;

    public ChoiceBox choiceBox;
    public DecisionBox decisionBox;

    //Left
    public Image imgEnemyPortrait;
    public Text textEnemyName;
    public EnemyAI enemyAI;
    public Image imgEnemyLoseDice;
    public Image imgMyLoseDice;
    public Text textEnemyLoseDice;
    public Text textMyLoseDice;
    public Text textMyName;

    public Text textEnemyDiceCount;
    public Text textMyDiceCount;

    public bool isCurrentJobEnded;
    public bool isSelectDiceEnded;

    //Right
    public ItemManager enemyItemManager;
    public ItemManager myItemManager;
    public GameObject objCheckedDiceBox;
    public Dice checkedDice;
    public Text textCheckedLabel;

    //Challenge
    public Image imgChallenge;
    public Image[] imgChallengeResults;
    public Text textResultValue;
    public Text textChoiceValue;
    public int resultValue;

    public GameObject objGameOver;
    public Image portraitGameOver;
    public Text textGameOver;

    public ThinkingBox thinkingBox;
    public Text textThinking;

    //Tutorials
    public TutorialHelper tutorialHelper;
    public GameObject objCursor;
    public GameObject objTextBox;
    public GameObject objSkipTutorial;
    public Text textSkipTutorial;
    public Text textSkipTutorialYes;
    public Text textSkipTutorialNo;

    //ItemUse
    public Image imgMsgUseItem;
    public Text textMsgUseItem;

    //Menu
    public Text textRetry;
    public Text textMenu;

    public Image imageSword;

    public ScoreBox scoreBox;

    public GameResult gameResult;

    public int roundNum = 0;
    public int turnNum = 0;

    int playTutorial = 0;
    bool checkTutorial = false;
    int currentDmg = 1;

    private void Awake()
    {
        if (duelSM == null)
            duelSM = this;
        else
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        duelSM = null;
    }

    private void Start()
    {
        ChangeLang();
        StartCoroutine(GameProcess());
    }

    public void ReSetUI()
    {
        textRoundBig.text = "";
        textRound.text = "";
        objGameOver.SetActive(false);
        imgChallenge.SetActive(false);
        foreach (Image img in imgChallengeResults)
            img.SetActive(false);
        decisionBox.SetActive(false);
        imgEnemyLoseDice.SetActive(false);
        imgMyLoseDice.SetActive(false);

        scoreBox.SetActive(false);
        portraitGameOver.SetActive(false);
        objCursor.SetActive(false);
        (scoreBox.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
        objTextBox.SetActive(false);

        //Left
        textEnemyDiceCount.SetActive(false);
        textMyDiceCount.SetActive(false);

        objSkipTutorial.SetActive(false);

        //Right
        myItemManager.Reset();
        enemyItemManager.Reset();
        objCheckedDiceBox.SetActive(false);

        //UseItem
        imgMsgUseItem.SetActive(false);
        myItemManager.objSelectDiceCover.SetActive(false);
    }

    IEnumerator GameProcess()
    {
        gameState = GameState.BeforeStart;
        ReSetUI();
        gameResult = new GameResult();
        gameResult.startTime = System.DateTime.Now;

        conditionDatas.Set();

        yield return null;
        //playTutorial = PlayerPrefs.GetInt(TutorialKey, 0);

        if(playTutorial < 7)
        {
            objSkipTutorial.SetActive(true);
            yield return new WaitUntil(() => checkTutorial);
        }

        for (int i = 1; i <= 5; i++)
        {
            roundNum = i;
            enemyAI.MistakeValue = 0.15f - (i * 0.2f);
            yield return StartCoroutine(RoundProcess(i));

            if (myDiceBox.diceCount <= 0)
            {
                GameOver(i);
                break;
            }
        }

        if(myDiceBox.diceCount > 0)
            GameEnd();
    }

    //Play With All Current Dice
    IEnumerator RoundProcess(int roundNum)
    {
        gameResult.currentRound = roundNum;

        if(playTutorial == (int)TutorialProcess.StartTutorial)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.StartTutorial));
            playTutorial = (int)TutorialProcess.RollDice;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.RollDice);
        }

        currentDmg = gameManager.mode == GameMode.LoseDouble ? 2 : 1;
        textEnemyLoseDice.text = $"-{currentDmg}";
        textMyLoseDice.text = $"-{currentDmg}";

        objCheckedDiceBox.SetActive(false);

        textRound.text = "";
        imgEnemyPortrait.sprite = imageManager.portraitSprites[roundNum - 1];
        textEnemyName.text = Texts.enemyNames[roundNum - 1, (int)OptionList.languageType];
        textRoundBig.text = $"Round {roundNum}";
        yield return StartCoroutine(FadeManager.FadeIn(textRoundBig, 1));
        yield return Utilities.WaitForOneSecond;
        yield return StartCoroutine(FadeManager.FadeOut(textRoundBig, 1));
        textRoundBig.SetActive(false);
        yield return null;

        textRound.text = $"Round {roundNum}";
        yield return StartCoroutine(FadeManager.FadeIn(textRound, 1));

        gameState = GameState.SetDiceNum;
        enemyDiceBox.diceCount = roundNum;
        myDiceBox.diceCount = gameManager.mode == GameMode.OneDice ? 1 : roundNum;

        if(roundNum >= 2 && playTutorial == (int)TutorialProcess.UsingItem)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.UsingItem));
            playTutorial = (int)TutorialProcess.UsingItem;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.EndTutorial);
        }

        gameState = GameState.GetItem;
        yield return StartCoroutine(AddItem(roundNum));

        turnNum = 0;
        for (int i = 0; i < roundNum * 2; i++)
        {
            yield return StartCoroutine(SingleProcess(roundNum));

            if (myDiceBox.diceCount <= 0 || enemyDiceBox.diceCount <= 0)
                break;
        }

        textEnemyDiceCount.SetActive(false);
        textMyDiceCount.SetActive(false);

        yield return new WaitForSeconds(2);
    }

    //Play With Single Dice
    public bool isChallengeStarted = false;
    bool isMyChoice;
    bool isChallengeSuccess = false;

    IEnumerator SingleProcess(int roundNum)
    {
        isMyChoice = roundNum % 2 == 0;

        //Roll Dice
        if (playTutorial <= (int)TutorialProcess.RollDice)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.RollDice));
            playTutorial = (int)TutorialProcess.BeforeShowChoiceCard;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.BeforeShowChoiceCard);
        }

        audioManager.PlaySFX(AudioManager.SFX.DiceRoll);

        yield return new WaitForSeconds(2f);

        enemyDiceBox.Set();
        myDiceBox.Set();
        ShowDiceBoxes();

        textEnemyDiceCount.SetActive(true);
        textMyDiceCount.SetActive(true);
        textEnemyDiceCount.text = $"X {Math.Max(0, enemyDiceBox.diceCount)}";
        textMyDiceCount.text = $"X {Math.Max(0, myDiceBox.diceCount)}";

        choiceDatas.ResetCurrentIdx(myDiceBox.diceCount + enemyDiceBox.diceCount);

        checkedDice.SetActive(false);
        enemyAI.ResetCheckedDices();
        

        while (true)
        {
            turnNum++;
            isMyChoice = !isMyChoice;

            Vector3 tempScale = imageSword.transform.localScale;
            tempScale.y = isMyChoice ? 1 : -1;
            imageSword.transform.localScale = tempScale;

            yield return Utilities.WaitForOneSecond;

            if (isMyChoice)
                gameState = GameState.InChoice;
            else
                gameState = GameState.InDecision;

            if (isMyChoice)
            {
                //Before Dice
                if (playTutorial <= (int)TutorialProcess.BeforeShowChoiceCard)
                {
                    yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.BeforeShowChoiceCard));
                    playTutorial = (int)TutorialProcess.AfterShowChoiceCard;
                    PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.AfterShowChoiceCard);
                }


                yield return StartCoroutine(SelectChoice());
            }
            else
            {
                yield return StartCoroutine(SelectDecision());
            }

            yield return Utilities.WaitForOneSecond;

            if (isChallengeStarted)
            {
                gameState = GameState.InJudge;
                audioManager.bgmAudioSource.Pause();
                audioManager.PlaySFX(AudioManager.SFX.Challenge);
                yield return StartCoroutine(FadeManager.FadeIn(imgChallenge, 1));

                yield return Utilities.WaitForOneSecond;

                yield return StartCoroutine(FadeManager.FadeOut(imgChallenge, 1));
                audioManager.bgmAudioSource.Play();

                yield return StartCoroutine(Judge());

                yield return Utilities.WaitForOneSecond;

                HideDiceBoxes();
                break;
            }

            if (myDiceBox.diceCount == 0 || enemyDiceBox.diceCount == 0)
                break;
        }

        yield return null;
        isCurrentJobEnded = false;
    }

    IEnumerator SelectChoice()
    {
        yield return null;

        choiceBox.Show();

        if (playTutorial <= (int)TutorialProcess.AfterShowChoiceCard)
        {
            objCursor.SetActive(true);
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.AfterShowChoiceCard));
            objCursor.SetActive(false);
            playTutorial = (int)TutorialProcess.BeforeShowDecision;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.BeforeShowDecision);
        }

        yield return new WaitUntil(() => isCurrentJobEnded);
        isCurrentJobEnded = false;

        gameState = GameState.BaelzThinking;
        choiceBox.Hide();
        enemyAI.Decide();

        audioManager.PlaySFX(AudioManager.SFX.Hmm);
        StartCoroutine(thinkingBox.Show());

        yield return new WaitUntil(() => isCurrentJobEnded);
        isCurrentJobEnded = false;
        gameState = GameState.InChoice;
    }

    IEnumerator SelectDecision()
    {
        gameState = GameState.BaelzThinking;
        yield return null;
        enemyAI.Choose();

        audioManager.PlaySFX(AudioManager.SFX.Hmm);
        StartCoroutine(thinkingBox.Show());

        yield return new WaitUntil(() => isCurrentJobEnded);
        isCurrentJobEnded = false;

        gameState = GameState.InDecision;
        if (playTutorial <= (int)TutorialProcess.BeforeShowDecision)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.BeforeShowDecision));
            playTutorial = (int)TutorialProcess.AfterShowDecision;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.AfterShowDecision);
        }

        choiceBox.Hide();
        decisionBox.Show();

        if (playTutorial <= (int)TutorialProcess.AfterShowDecision)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.AfterShowDecision));
            playTutorial = (int)TutorialProcess.InJudge;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.InJudge);
        }

        yield return new WaitUntil(() => isCurrentJobEnded);
        isCurrentJobEnded = false;

        decisionBox.Hide();
    }

    IEnumerator Judge()
    {
        yield return null;

        isChallengeSuccess = false;

        var data = choiceDatas.GetCurrentChoiceData();
        switch (data.Item1)
        {
            case ChoiceType.Sum:
                int sum = myDiceBox.GetValueSum() + enemyDiceBox.GetValueSum();
                if (sum < data.Item2)
                    isChallengeSuccess = true;
                break;
            case ChoiceType.Multiple:
                break;
            case ChoiceType.Rat:
                int ratAmmount = myDiceBox.GetRatCount() + duelSM.enemyDiceBox.GetRatCount();
                if (ratAmmount < data.Item2)
                    isChallengeSuccess = true;
                break;
        }

        StartCoroutine(myDiceBox.ShowOneByOne());
        StartCoroutine(enemyDiceBox.ShowOneByOne());

        textResultValue.text = "0";
        textChoiceValue.text = $"/ {data.Item2}";
        yield return StartCoroutine(CalculateValue(data.Item1));

        yield return Utilities.WaitForHalfSecond;

        ChallengeResult result = ChallengeResult.Failed;
        if (isChallengeSuccess)
            result = ChallengeResult.Success;

        textChoiceValue.text = "";
        textResultValue.text = "";

        if (isChallengeSuccess)
            audioManager.PlayChallengeSuccess();
        else
            audioManager.PlayChallengeFailed();

        yield return StartCoroutine(FadeManager.FadeIn(imgChallengeResults[(int)result], 1));

        yield return Utilities.WaitForOneSecond;

        yield return StartCoroutine(FadeManager.FadeOut(imgChallengeResults[(int)result], 1));

        if (playTutorial <= (int)TutorialProcess.InJudge)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.InJudge));
            playTutorial = (int)TutorialProcess.UsingItem;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.UsingItem);
        }

        if ((isMyChoice && isChallengeSuccess == false) || (isMyChoice == false && isChallengeSuccess))
        {
            enemyDiceBox.diceCount -= currentDmg;
            audioManager.PlayBaelzLose();
            imgEnemyLoseDice.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            yield return StartCoroutine(FadeManager.ZoomInOut(imgEnemyLoseDice.transform, 1f));
            yield return new WaitForSeconds(0.2f);
        }
        else
        {
            myDiceBox.diceCount -= currentDmg;
            audioManager.PlayMeLose();

            imgMyLoseDice.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            yield return StartCoroutine(FadeManager.ZoomInOut(imgMyLoseDice.transform, 1f));
            yield return new WaitForSeconds(0.2f);
            gameResult.loseDices++;
        }

        textEnemyDiceCount.text = $"X {Math.Max(0, enemyDiceBox.diceCount)}";
        textMyDiceCount.text = $"X {Math.Max(0, myDiceBox.diceCount)}";

        isChallengeStarted = false;
    }

    IEnumerator CalculateValue(ChoiceType type)
    {
        resultValue = 0;
        int idx = 0;
        int value;
        yield return Utilities.WaitForHalfSecond;
        while (idx < 5)
        {
            switch (type)
            {
                case ChoiceType.Sum:
                    value = myDiceBox.GetValue(idx);
                    resultValue += value != 6 ? value : 0 ;
                    value = enemyDiceBox.GetValue(idx);
                    resultValue += value != 6 ? value : 0;
                    break;
                case ChoiceType.Multiple:
                    break;
                case ChoiceType.Rat:
                    value = myDiceBox.GetValue(idx);
                    resultValue += value == 6 ? 1 : 0;
                    value = enemyDiceBox.GetValue(idx);
                    resultValue += value == 6 ? 1 : 0;
                    break;
            }

            textResultValue.text = $"{resultValue} ";
            yield return Utilities.WaitForHalfSecond;
            idx++;
        }
    }


    IEnumerator AddItem(int round)
    {
        if (round / 2 == 0)
            yield break;
        audioManager.PlaySFX(AudioManager.SFX.Z_Beep);
        for(int i = 0; i < round / 2; i++)
        {
            enemyItemManager.AddItem((ItemType)Random.Range(0, (int)ItemType.DiceofWitness));
            myItemManager.AddItem((ItemType)Random.Range(0, (int)ItemType.DiceofWitness));
        }
        yield return Utilities.WaitForOneSecond;
    }

    public void ShowDiceBoxes()
    {
        myDiceBox.SetActive(true);
        enemyDiceBox.SetActive(true);
    }

    public void HideDiceBoxes()
    {
        myDiceBox.SetActive(false);
        enemyDiceBox.SetActive(false);
    }

    public void GameOver(int roundNum)
    {
        gameResult.isClear = false;
        StopAllCoroutines();
        objGameOver.SetActive(true);

        StartCoroutine(_GameOver(roundNum));
        PlayerPrefs.SetInt(TutorialKey, 1);
    }

    public IEnumerator _GameOver(int roundNum)
    {
        yield return StartCoroutine(scoreBox.Show());

        yield return Utilities.WaitForHalfSecond;
        yield return StartCoroutine(FadeManager.MoveRectTransform(scoreBox.transform as RectTransform, new Vector2(ScoreBoxOriginX, 0), new Vector2(ScoreBoxAfterX, 0), 1f));
        //yield return StartCoroutine(FadeManager.FadeOut(scoreBox.GetComponent<Image>(), 1));
        //(scoreBox.transform as RectTransform).anchoredPosition = new Vector2(-710, 0);
        //yield return StartCoroutine(FadeManager.FadeIn(scoreBox.GetComponent<Image>(), 1));

        portraitGameOver.SetActive(true);
        portraitGameOver.sprite = imageManager.portraitSprites[roundNum - 1];
        objTextBox.SetActive(true);
        StartCoroutine(TutorialHelper.Typing(textGameOver, Texts.messageGameOver[Random.Range(0, Texts.messageGameOver.Length / 2), (int)OptionList.languageType]));
        audioManager.PlayGameOver();
    }

    public void GoToNextRound()
    {
        isCurrentJobEnded = false;
    }

    public void GameEnd()
    {
        gameResult.isClear = true;
        StopAllCoroutines();
        objGameOver.SetActive(true);

        StartCoroutine(_GameEnd());
        PlayerPrefs.SetInt(TutorialKey, 1);
    }

    public IEnumerator _GameEnd()
    {
        yield return StartCoroutine(scoreBox.Show());

        yield return StartCoroutine(FadeManager.FadeOut(scoreBox.GetComponent<Image>(), 1));
        (scoreBox.transform as RectTransform).anchoredPosition = new Vector2(-710, 0);
        yield return StartCoroutine(FadeManager.FadeIn(scoreBox.GetComponent<Image>(), 1));

        portraitGameOver.SetActive(true);
        portraitGameOver.sprite = imageManager.portraitSprites[imageManager.portraitSprites.Length - 1];

        int num = Random.Range(0, 3);
        objTextBox.SetActive(true);
        StartCoroutine(TutorialHelper.Typing(textGameOver, Texts.messageGameEnd[num, (int)OptionList.languageType]));
        audioManager.PlayGameEnd(num);
    }

    public void OnRetry()
    {
        StopAllCoroutines();
        StartCoroutine(GameProcess());
    }

    public void OnExit()
    {
        gameManager.LoadScene("Menu");
    }

    public void SkipTutorial()
    {
        checkTutorial = true;
        playTutorial = (int)TutorialProcess.EndTutorial;
        objSkipTutorial.SetActive(false);
    }

    public void NotSkipTutorial()
    {
        checkTutorial = true;
        objSkipTutorial.SetActive(false);
    }

    public void ChangeLang()
    {
        textSkipTutorial.text = Texts.skipTutorialLabels[0, (int)OptionList.languageType];
        textSkipTutorialYes.text = Texts.skipTutorialLabels[1, (int)OptionList.languageType];
        textSkipTutorialNo.text = Texts.skipTutorialLabels[2, (int)OptionList.languageType];
        textMyName.text = Texts.myNameLabels[(int)OptionList.languageType];
        textThinking.text = Texts.thinkingLabels[(int)OptionList.languageType];
        textRetry.text = Texts.retryLabels[(int)OptionList.languageType];
        textMenu.text = Texts.exitLabels[(int)OptionList.languageType];
        textCheckedLabel.text = Texts.checkedDiceLabels[(int)OptionList.languageType];
    }

    public void AddDice(bool isPlayer, int count)
    {
        if (isPlayer)
            myDiceBox.AddDice(count, gameState != GameState.InJudge || gameState != GameState.BaelzThinking);
        else
            enemyDiceBox.AddDice(count, gameState != GameState.InJudge || gameState != GameState.BaelzThinking);
    }

    public void CheckEnemyDice(bool isPlayer, int count)
    {
        if (isPlayer)
        {
            int value = enemyDiceBox.GetValue(0);
            checkedDice.Roll(value, -1);
            checkedDice.SetActive(true);
            objCheckedDiceBox.SetActive(true);
        }
        else
        {
            int value = myDiceBox.GetValue(0);
            enemyAI.SetCheckedDices(new List<int>() { value });
        }
    }

    public void AddDamage(int dmg)
    {
        currentDmg += dmg;
        textEnemyLoseDice.text = $"-{currentDmg}";
        textMyLoseDice.text = $"-{currentDmg}";
    }

    public void NoticeItemUse(bool isPlayer, ItemType type)
    {
        StartCoroutine(_NoticeItemUse(isPlayer, type));
    }

    IEnumerator _NoticeItemUse(bool isPlayer, ItemType type)
    {
        if (OptionList.languageType == LanguageType.English)
        {
            if(isPlayer == false)
                textMsgUseItem.text = Texts.baelzItemUseDesc_Eng_Front + Texts.itemNames[(int)type, (int)OptionList.languageType] + Texts.baelzItemUseDesc_Eng_End;
            else
                textMsgUseItem.text = Texts.playerItemUseDesc_Eng_Front + Texts.itemNames[(int)type, (int)OptionList.languageType] + Texts.playerItemUseDesc_Eng_End;
        }
        else if (OptionList.languageType == LanguageType.Korean)
        {
            if(isPlayer == false)
                textMsgUseItem.text = Texts.baelzItemUseDesc_Kor_Front + Texts.itemNames[(int)type, (int)OptionList.languageType] + Texts.baelzItemUseDesc_Kor_End;
            else
                textMsgUseItem.text = Texts.playerItemUseDesc_Kor_Front + Texts.itemNames[(int)type, (int)OptionList.languageType] + Texts.playerItemUseDesc_Kor_End;
        }
        FadeManager.FadeIn(imgMsgUseItem, 1);
        yield return Utilities.WaitForOneSecond;
        FadeManager.FadeOut(imgMsgUseItem, 1);
    }

    public void SelectRollDice()
    {
        StartCoroutine(_SelectRerollDice());
    }

    IEnumerator _SelectRerollDice()
    {
        isSelectDiceEnded = false;
        myItemManager.objSelectDiceCover.SetActive(true);

        myDiceBox.SetDiceClickable();
        yield return new WaitUntil(() => isSelectDiceEnded);

        myDiceBox.SetDiceUnClickable();
        myItemManager.objSelectDiceCover.SetActive(false);
    }

#if UNITY_EDITOR
    private void Update()
    {
        for(int i = 0; i < 9; i++)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1 + i))
            {
                myItemManager.AddItem((ItemType)i);
            }
        }
    }
#endif
}
