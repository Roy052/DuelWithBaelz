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
            Dialog = new string[] { "Where am I?", "여기는 어디지?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "Of course, it's a place where you play game.", "물론 게임을 하는 곳이지요."}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "Who... are you?", "누.. 구세요?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "My name is Hayko, who serves customers here.", "이곳에서 손님들에게 서비스를 제공하는 헤이코라고 합니다."}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Question, 
            Dialog = new string[] { "Is there someone who's going to play the game?", "거기 게임을 할 사람이 온거야?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Yes.", "그래" }},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "What game?", "무슨 게임이요?" }},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "Let's go in and talk about.", "일단 들어가서 이야기하시죠."}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "So what am I doing?", "그래서 뭘 하는거죠?"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae, 
            Dialog = new string[] { "What? You didn't explain it?", "뭐야 설명 안 해준거야?"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "I was just going to do it, but you called it.", "방금 하려했는데 네가 불렀잖아."}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "This game uses dice and cards", "일단 이 게임은 주사위와 카드를 이용하는 게임으로"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "one who loses all the dice loses.", "주사위를 모두 잃은 쪽이 지는 게임입니다"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"Roll the dice first", "먼저 주사위를 굴리고"}},
        new Tutorial(){ id = 2, tutorialType = TutorialType.Button, characterType = CharacterType.Me, 
            Dialog = new string[] {"RollDice", ""}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "If you check the dice, there are 1 to 5 cheeses and 1 mouse.", "주사위를 확인해보면 1~5 개의 치즈와 1개의 쥐가 그려져있습니다."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "After checking the dice, select the choice card.", "주사위를 확인한 후 선택지 카드를 뽑습니다."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] { "What choice is this?", "이건 무슨 선택지인가요?"}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "It's a choice to lose the dice if you're wrong.", "틀릴 경우 주사위를 잃을 수 있는 선택지입니다."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] { "Combine each other's dice and choose the most likely option.", "서로의 주사위를 합쳐 가능성이 높은 선택지를 골라주세요."}},
        new Tutorial(){ id = 4, tutorialType = TutorialType.SelectCard, characterType = CharacterType.Me, 
            Dialog = new string[] {"", ""}},
        new Tutorial(){ id = 5, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Then, your opponent will now decide whether to check this choice or not.", "그러면 이제 상대가 이 선택지를 확인할 지 말지 결정하게 됩니다."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Now it's your turn to check other's choice.", "이젠 당신이 선택지를 검증할 차례입니다."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me,
            Dialog = new string[] { "I can predict and calculate the other's dice after looking at my dice.", "내 주사위를 보고 상대 주사위를 예측해 계산하면 되겠군요."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae,
            Dialog = new string[] { "You're learning fast.", "배우는 게 빠른데."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Press the challenge button here to check this choice, and press the pass button to select the choice card.", "여기서 도전 버튼을 누르면 이 선택지를 확인하고, 패스 버튼을 누르면 당신이 선택지 카드를 뽑게 됩니다."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "If the choice is false, the person who picks the choice loses the dice, and if the choice is true, the checked person loses the dice.", "만약 선택지가 거짓일 경우 선택지를 뽑은 사람이 주사위를 잃고, 선택지가 참일 경우 검증한 사람이 주사위를 잃습니다."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Repeat the choose and check like this, and once someone loses the dice, they roll all the dice again and repeat the previous process.", "이렇게 선택지와 확인을 반복하다 누군가 주사위를 잃고 나면 다시 모든 주사위를 굴리고 이전 과정을 반복하게 됩니다."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae,
            Dialog = new string[] { "I think I've explained enough. Shall we start?", "이정도면 충분히 설명한 것 같은데 시작해볼까?"}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "You can get items in certain rounds.", "특정 라운드에선 아이템을 얻을 수 있습니다."}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "Items can only be used during choice and check.", "선택지를 뽑는 동안, 검증을 하는 동안만 아이템을 사용할 수 있습니다."}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] { "If you mouse over the item, you can see the effect and use it with a mouse click.", "아이템에 마우스를 갖다 대면 효과를 알 수 있고 마우스 클릭으로 사용합니다."}},
    };
}
