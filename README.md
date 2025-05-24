# Duel With Baelz
<div>
    <h2> 게임 정보 </h2>
    <img src = "https://img.itch.zone/aW1nLzE1Mjk4MjAzLnBuZw==/315x250%23c/GfWKKw.png"><br>
    <img src="https://img.shields.io/badge/Unity-yellow?style=flat-square&logo=Unity&logoColor=FFFFFF"/>
    <img src="https://img.shields.io/badge/Strategy-red"/>
    <h4> 개발 일자 : 2024.08 <br><br>
    플레이 : https://goodstarter.itch.io/duelwithbaelz
    
  </div>
  <div>
    <h2> 게임 설명 </h2>
    <h3> 스토리 </h3>
     벨즈와 주사위를 걸고 대결을 펼친다. <br><br>
     내 주사위를 가지고 상대의 수에 대응하라.
    <h3> 게임 플레이 </h3>
     매 라운드 주사위가 주어지고 서로 주사위와 관련된 선택지를 고릅니다.<br><br>
     골라진 선택지를 보고 상대방은 이 선택지가 참인지 여부를 결정합니다.<br><br>
     참이 아니라고 생각하면 도전 버튼을 누를 수 있고 이 도전의 결과에 따라 1명이 주사위를 잃습니다.<br><br>
     모든 주사위를 잃는 사람이 생기면 라운드가 종료되고 상대방이 주사위를 모두 잃었을 경우 다음 라운드로 진행합니다.<br><br>
  </div> 
  <div>
    <h2> 게임 스크린샷 </h2>
      <table>
        <td><img src = "https://img.itch.zone/aW1hZ2UvMjU2ODYwMi8xODI0NjE0NS5wbmc=/250x600/WlZgSR.png"></td>
        <td><img src = "https://img.itch.zone/aW1hZ2UvMjU2ODYwMi8xODI0NjE0Ny5wbmc=/250x600/BWB%2FYy.png"></td>
        <td><img src = "https://img.itch.zone/aW1hZ2UvMjU2ODYwMi8xODI0NjE0OC5wbmc=/250x600/wjKJ6j.png"></td>
      </table>
  </div>
    <div>
    <h2> 게임 플레이 영상 </h2>
    https://youtu.be/dmjHdEKy-bA
  </div>
  <div>
    <h2> 배운 점 </h2>
    회사에서 배운 다양한 유니티 C# 기능을 활용했다. <br><br>
      this 기능이라던지, anchoredPosition을 이용하는 방식이라던지 UnityAction을 활용하는 방식 등. <br><br>
      Dictionary, Pair, List 등 다양한 자료구조를 활용하게 되었다.
  </div>

   <div>
       <h2> 주요 코드 </h2>
       <h4> Enemy AI 값 계산 </h4>
    </div>
    
```csharp
Dictionary<(int, int), float> probSumValues = new Dictionary<(int, int), float>();
Dictionary<(int, int), float> probRatValues = new Dictionary<(int, int), float>();
List<float> notExistProbValues = new List<float>() { 1 };
List<float> existProbValues = new List<float>() { 1 };

List<int> checkedDices = new List<int>();

public float CalculateProbabilitySum(int diceAmmount, int sum)
{
    if (sum < 0)
        return 1;

    if (probSumValues.ContainsKey((diceAmmount, sum)))
        return probSumValues[(diceAmmount, sum)] + Random.Range(-MistakeValue, MistakeValue);

    int minValue = diceAmmount;
    int averageValue = diceAmmount * 3;
    int maxValue = diceAmmount * 5;

    float lineWidth = Mathf.Min(averageValue - minValue, maxValue - sum) / (float)(maxValue - averageValue);
    float prob = lineWidth * lineWidth * 0.5f;

    if (sum < averageValue)
    {
        lineWidth = (sum - minValue) / (float)(averageValue - minValue);
        prob += 0.5f - (lineWidth * lineWidth * 0.5f);
    }

    Debug.Log($"P({sum},{diceAmmount}) = {prob}");

    probSumValues.Add((diceAmmount, sum), prob);

    prob += Random.Range(-MistakeValue, MistakeValue);

    return prob;
}
```
<div>
       <h4> 게임 진행 (DuelSM) </h4>
</div>
    
```csharp
IEnumerator SingleProcess(int roundNum)
    {
        isMyChoice = roundNum % 2 == 0;

        //Before Roll Dice
        if (playTutorial <= (int)TutorialProcess.BeforeRollDice)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.BeforeRollDice));
            playTutorial = (int)TutorialProcess.ClickRollDiceBtn;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.ClickRollDiceBtn);
        }

        //Roll Dice Btn
        if (playTutorial <= (int)TutorialProcess.ClickRollDiceBtn)
        {
            yield return StartCoroutine(tutorialHelper.ShowTutorial((int)TutorialProcess.ClickRollDiceBtn));
            playTutorial = (int)TutorialProcess.CheckDiceAndChoice;
            PlayerPrefs.SetInt(TutorialKey, (int)TutorialProcess.CheckDiceAndChoice);
        }
        audioManager.PlaySFX(AudioManager.SFX.DiceRoll);

        yield return new WaitForSeconds(2f);

        enemyDiceBox.Set();
        myDiceBox.Set();
        ShowDiceBoxes();

        RefreshDiceCount();

        choiceDatas.ResetCurrentIdx(myDiceBox.diceCount + enemyDiceBox.diceCount);

        checkedDice.SetActive(false);
        enemyAI.ResetCheckedDices();
        

        while (true)
        {
            turnNum++;
            isMyChoice = !isMyChoice;

            for(int i = 0; i < currentDmg; i++)
            {
                Vector3 tempScale = imageSwords[i].transform.localScale;
                tempScale.y = isMyChoice ? 1 : -1;
                imageSwords[i].transform.localScale = tempScale;
            }
            
            yield return Utilities.WaitForOneSecond;

            if (isMyChoice)
                gameState = GameState.InChoice;
            else
                gameState = GameState.InDecision;

            if (isMyChoice)
            {
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
```
