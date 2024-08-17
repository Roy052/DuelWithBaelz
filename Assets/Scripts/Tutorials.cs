public enum TutorialType
{
    Dialog = 0,
    Button = 1,
    SelectCard = 2,
    SelectDecision = 3,
}

public enum CharacterType
{
    None = -1,
    Me = 0,
    Hayko = 1,
    Question = 2,
    Bae = 3,
    Max = 4,
}

public class Tutorial
{
    public int id;
    public TutorialType tutorialType;
    public CharacterType characterType;
    public string[] Dialog;
}

public static class Tutorials
{
    public static Tutorial[] tutorials =
    {
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "Where am I?", "����� �����?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "Of course, it's a place where you play game.", "���� ������ �ϴ� ��������."}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "Who... are you?", "��.. ������?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "My name is Hayko, who serves customers here.", "�̰����� �մԵ鿡�� ���񽺸� �����ϴ� �����ڶ�� �մϴ�."}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Question, 
            Dialog = new string[] { "Is there someone who's going to play the game?", "�ű� ������ �� ����� �°ž�?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Yes.", "�׷�" }},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "What game?", "���� �����̿�?" }},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "Let's go in and talk about.", "�ϴ� ���� �̾߱��Ͻ���."}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "So what am I doing?", "�׷��� �� �ϴ°���?"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae, 
            Dialog = new string[] { "What? You didn't explain it?", "���� ���� �� ���ذž�?"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "I was just going to do it, but you called it.", "��� �Ϸ��ߴµ� �װ� �ҷ��ݾ�."}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "This game uses dice and cards", "�ϴ� �� ������ �ֻ����� ī�带 �̿��ϴ� ��������"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "one who loses all the dice loses.", "�ֻ����� ��� ���� ���� ���� �����Դϴ�"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"Roll the dice first", "���� �ֻ����� ������"}},
        new Tutorial(){ id = 2, tutorialType = TutorialType.Button, characterType = CharacterType.Me, 
            Dialog = new string[] {"RollDice", ""}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "If you check the dice, there are 1 to 5 cheeses and 1 mouse.", "�ֻ����� Ȯ���غ��� 1~5 ���� ġ��� 1���� �㰡 �׷����ֽ��ϴ�."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "After checking the dice, select the choice card.", "�ֻ����� Ȯ���� �� ������ ī�带 �̽��ϴ�."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "What choice is this?", "�̰� ���� �������ΰ���?"}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "It's a choice to lose the dice if you're wrong.", "Ʋ�� ��� �ֻ����� ���� �� �ִ� �������Դϴ�."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "Combine each other's dice and choose the most likely option.", "������ �ֻ����� ���� ���ɼ��� ���� �������� ����ּ���."}},
        new Tutorial(){ id = 4, tutorialType = TutorialType.SelectCard, characterType = CharacterType.Me, 
            Dialog = new string[] {"", ""}},
        new Tutorial(){ id = 5, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Then, your opponent will now decide whether to check this choice or not.", "�׷��� ���� ��밡 �� �������� Ȯ���� �� ���� �����ϰ� �˴ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Now it's your turn to check other's choice.", "���� ����� �������� ������ �����Դϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me,
            Dialog = new string[] { "I can predict and calculate the other's dice after looking at my dice.", "�� �ֻ����� ���� ��� �ֻ����� ������ ����ϸ� �ǰڱ���."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae,
            Dialog = new string[] { "You're learning fast.", "���� �� ������."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Press the challenge button here to check this choice, and press the pass button to select the choice card.", "���⼭ ���� ��ư�� ������ �� �������� Ȯ���ϰ�, �н� ��ư�� ������ ����� ������ ī�带 �̰� �˴ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "If the choice is false, the person who picks the choice loses the dice, and if the choice is true, the checked person loses the dice.", "���� �������� ������ ��� �������� ���� ����� �ֻ����� �Ұ�, �������� ���� ��� ������ ����� �ֻ����� �ҽ��ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Repeat the choose and check like this, and once someone loses the dice, they roll all the dice again and repeat the previous process.", "�̷��� �������� Ȯ���� �ݺ��ϴ� ������ �ֻ����� �Ұ� ���� �ٽ� ��� �ֻ����� ������ ���� ������ �ݺ��ϰ� �˴ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae,
            Dialog = new string[] { "I think I've explained enough. Shall we start?", "�������� ����� ������ �� ������ �����غ���?"}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "You can get items in certain rounds.", "Ư�� ���忡�� �������� ���� �� �ֽ��ϴ�."}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Items can only be used during choice and check.", "�������� �̴� ����, ������ �ϴ� ���ȸ� �������� ����� �� �ֽ��ϴ�."}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "If you mouse over the item, you can see the effect and use it with a mouse click.", "�����ۿ� ���콺�� ���� ��� ȿ���� �� �� �ְ� ���콺 Ŭ������ ����մϴ�."}},
    };
}
