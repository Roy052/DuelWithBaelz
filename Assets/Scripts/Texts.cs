public class Texts
{
    public static string[,] menuLabels = new string[,]
    {
        { "Play", "���� ����" },
        { "Play Mode", "���� ���" },
        { "Options", "����" },
    };

    public static string[,] optionLabels = new string[,]
    {
        { "Language", "���" },
        { "BGM", "�������" },
        { "SFX", "ȿ����"},
    };

    public static string[,] modeLabels = new string[,]
     {
        { "One Dice Mode", "�ֻ��� �� �� ���" },
        { "Lose Double Mode", "2��� �Ҵ� ���" },
     };

    public static string[,] decisionLabels = new string[,]
    {
        { "Challenge", "����" },
        { "Pass", "�ѱ��" },
    };

    public static string[,] skipTutorialLabels = new string[,]
    {
        { "Skip Tutorial?", "Ʃ�丮���� ��ŵ�Ͻðڽ��ϱ�?" },
        { "YES", "��" },
        { "NO", "�ƴϿ�"},
    };

    public static string[] languageValues = new string[]
    {
        "English",
        "�ѱ���"
    };

    public static string[,] enemyNames = new string[,] {
        { "Hakos Baelz", "���ڽ� ����" },
        { "Fashion Bae", "���� �ǻ� ����" },
        { "Tasmanian Bae", "������̴Ͼ� ����" },
        { "New Year Bae", "�ų��ǻ� ����" },
        { "Smol Bae", "Smol ����" },
    };

    public static string[] myNameLabels =
    {
        "BRAT",
        "�귧��",
    };

    public static string[] thinkingLabels =
    {
        "Bae\'s thinking...",
        "���̰� ���� ��..."
    };

    public static string[] retryLabels =
    {
        "Retry",
        "�ٽ��ϱ�"
    };

    public static string[] exitLabels =
    {
        "Menu",
        "�޴���"
    };

    public static string[,] messageGameOver = new string[,] {
        { "One more?", "�� �� ��?" },
        { "It's so close.", "�Ʊ���" },
        { "Victory tastes so sweet.", "������ ���Ŵ� �����ϳ�" },
        { "Thanks.", "����" },
    };
    public static string[,] messageGameEnd = new string[,] {
        { "I\'ll be fine.. I hope", "������... �Ƹ���" },
        { "You're just lucky. Let's just leave it to that.", "���� ���ҳ�. �װ� ���̾�" },
        { "Just practice.", "�׳� ���� �����̾�" },
    };

    public static string[,] ChoiceDesc = new string[,]{
        { "The number of Cheese is ", "ġ���� ���� " },
        { "", "" },
        { "The number of Rat is ", "���� ���� " }
    };

    public static string[] ChoiceTail = 
    {
        " or more.",
        " �̻�."
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

            {"\"Duel with baelz\"�� ���� �� ȯ���մϴ�", "�� ������ \"Perudo\"��� ���ӿ��� ���Խ��ϴ�.", "\"Perudo\"�� ���� �𸣽ó���?", "����������. ó������ �˷��帱�״ϱ��." },
            {"����, �ֻ����� �����ϴ�.", "�ֻ������� �� �Ǵ� ġ� �׷����ֽ��ϴ�.",  "�ֻ��� 6�� �� 1�鿡�� �㰡 �׷����ְ�,", "������ �鿡�� ġ� 1~5��ŭ �׷����ֽ��ϴ�."},
            {"����, ī�� 3�� �� 1���� �����մϴ�.", "", "", ""},
            {"���ɼ��� �ִ� ������ ���� ī�带 �����մϴ�.", "������ � �ֻ����� ������ ������ �����ؾ� �մϴ�." , "", "" },
            {"����, ������ ������ ������ ����� �ƴ϶�� ������ ���", "���� ��ư�� ���� ���濡�� ���� �� �� �ֽ��ϴ�.", "�ƴ϶�� �ѱ�ø� �˴ϴ�.", ""},
            {"������ ���, ������ �ֻ����� �����ϰ� ������ �����ϴ��� Ȯ���մϴ�", "������ ������ ���, ������ ������ ����� �ֻ����� 1�� �ҽ��ϴ�.", "������ ������ ���, ������ �ֻ����� 1�� �ҽ��ϴ�.", ""},
            {"����������, ����� ��� �ֻ����� ������ ���ӿ��� �й��մϴ�.", "���� ������ �ֻ����� ��� ������ ���� ����� �̵��մϴ�.", "5���带 �¸��� ���, ���ӿ��� �¸��մϴ�.", "����� ���ϴ�."},
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
            "���� Ŭ���� ����",
            "���� ����",
            "�ֻ��� ����",
            "�ð� ����"
        }
    };
}
