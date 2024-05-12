public class Texts
{
    public static string[,] menuLabels = new string[,]
    {
        { "Play", "게임 시작" },
        { "Play Mode", "게임 모드" },
        { "Options", "설정" },
    };

    public static string[,] optionLabels = new string[,]
    {
        { "Language", "언어" },
        { "BGM", "배경음악" },
        { "SFX", "효과음"},
    };

    public static string[,] modeLabels = new string[,]
     {
        { "One Dice Mode", "주사위 한 개 모드" },
        { "Lose Double Mode", "2배로 잃는 모드" },
     };

    public static string[,] decisionLabels = new string[,]
    {
        { "Challenge", "도전" },
        { "Pass", "넘기기" },
    };

    public static string[,] skipTutorialLabels = new string[,]
    {
        { "Skip Tutorial?", "튜토리얼을 스킵하시겠습니까?" },
        { "YES", "네" },
        { "NO", "아니오"},
    };

    public static string[] languageValues = new string[]
    {
        "English",
        "한국어"
    };

    public static string[,] enemyNames = new string[,] {
        { "Hakos Baelz", "하코스 벨즈" },
        { "Fashion Bae", "멋진 의상 베이" },
        { "Tasmanian Bae", "태즈메이니아 베이" },
        { "New Year Bae", "신년의상 베이" },
        { "Smol Bae", "Smol 베이" },
    };

    public static string[] myNameLabels =
    {
        "BRAT",
        "브랫츠",
    };

    public static string[] thinkingLabels =
    {
        "Bae\'s thinking...",
        "베이가 생각 중..."
    };

    public static string[] retryLabels =
    {
        "Retry",
        "다시하기"
    };

    public static string[] exitLabels =
    {
        "Menu",
        "메뉴로"
    };

    public static string[,] messageGameOver = new string[,] {
        { "One more?", "한 판 더?" },
        { "It's so close.", "아깝네" },
        { "Victory tastes so sweet.", "승자의 열매는 달콤하네" },
        { "Thanks.", "고마워" },
    };
    public static string[,] messageGameEnd = new string[,] {
        { "I\'ll be fine.. I hope", "괜찮아... 아마도" },
        { "You're just lucky. Let's just leave it to that.", "운이 좋았네. 그것 뿐이야" },
        { "Just practice.", "그냥 연습 게임이야" },
    };

    public static string[,] ChoiceDesc = new string[,]{
        { "The number of Cheese is ", "치즈의 합이 " },
        { "", "" },
        { "The number of Rat is ", "쥐의 합이 " }
    };

    public static string[] ChoiceTail = 
    {
        " or more.",
        " 이상."
    };


    public static string[,,] TutorialTexts = {
        {
            {"Welcome to \"Duel with baelz\".", "This game is based on \"Perudo\".", "You don't know what the \"Perudo\" is?", "Don't worry I'll show you how to play." },
            {"First, Roll your dice.", "There is a rat or cheese on the dice.",  "Of the six sides, one side is a rat,", "and the other sides are 1~5 cheese."},
            {"Second, You have to choose one of three cards.", "", "", ""},
            {"Select this card to declare the text is true.", "You have to predict what kind of dice baelz had." , "", "" },
            {"Third, If you think card text may not be true", "You can challenge to press button.", "Or just pass.", ""},
            {"In this time, We have to judge this condition by showing our dice", "If challenge success The one who choose card lose one dice.", "If challenge failed, opponents lose one dice", ""},
            {"Fourth, If all of your dice is gone, you lose this game", "But if all of my dice is gone, you're moving to the next round", "After 5 rounds, You finally clear this game", "Good luck" },
        },
        {

            {"\"Duel with baelz\"에 오신 걸 환영합니다", "이 게임은 \"Perudo\"라는 게임에서 따왔습니다.", "\"Perudo\"가 뭔지 모르시나요?", "걱정마세요. 처음부터 알려드릴테니까요." },
            {"먼저, 주사위를 굴립니다.", "주사위에는 쥐 또는 치즈가 그려져있습니다.",  "주사위 6면 중 1면에는 쥐가 그려져있고,", "나머지 면에는 치즈가 1~5만큼 그려져있습니다."},
            {"다음, 카드 3장 중 1장을 선택합니다.", "", "", ""},
            {"가능성이 있는 조건이 적힌 카드를 선택합니다.", "상대방이 어떤 주사위를 가지고 있을지 예상해야 합니다." , "", "" },
            {"다음, 상대방이 제시한 조건이 사실이 아니라고 생각할 경우", "도전 버튼을 눌러 상대방에게 도전 할 수 있습니다.", "아니라면 넘기시면 됩니다.", ""},
            {"도전한 경우, 서로의 주사위를 공개하고 조건이 성립하는지 확인합니다", "도전에 성공한 경우, 조건을 선택한 사람은 주사위를 1개 잃습니다.", "도전에 실패한 경우, 상대방이 주사위를 1개 잃습니다.", ""},
            {"마지막으로, 당신의 모든 주사위를 잃으면 게임에서 패배합니다.", "만약 벨즈의 주사위를 모두 잃으면 다음 라운드로 이동합니다.", "5라운드를 승리한 경우, 게임에서 승리합니다.", "행운을 빕니다."},
        },
    };

    public static string[,] scoreDesc =
    {
        {
            "Game Clear Score",
            "Round Score",
            "Dice Score",
            "Elapsed Time Score"
        },
        {
            "게임 클리어 점수",
            "라운드 점수",
            "주사위 점수",
            "시간 점수"
        }
    };
}
