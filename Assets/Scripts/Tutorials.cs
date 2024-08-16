using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Dialog = new string[] {"Where am I", "����� ���ϴ� ������?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"Where am I", "���� ������ �ϴ� ��������"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] {"Where am I", "��.. ������?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "�̰����� �մԵ鿡�� ���񽺸� �����ϴ� �����ڶ�� �մϴ�."}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Question, 
            Dialog = new string[] {"", "�ű� ������ �� ����� �°ž�?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "�׷�"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] {"", "���� �����̿�?"}},
        new Tutorial(){ id = 0, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "�ϴ� ���� �̾߱��Ͻ���"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] {"", "�׷��� �� �ϴ°���?"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae, 
            Dialog = new string[] {"", "���� ���� �� ���ذž�?"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "��� �Ϸ��ߴµ� �װ� �ҷ��ݾ�"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "�ϴ� �� ������ �ֻ����� ī�带 �̿��ϴ� ��������"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "�ֻ����� ��� ���� ���� ���� �����Դϴ�"}},
        new Tutorial(){ id = 1, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "���� �ֻ����� ������"}},
        new Tutorial(){ id = 2, tutorialType = TutorialType.Button, characterType = CharacterType.Me, 
            Dialog = new string[] {"RollDice", ""}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "�ֻ����� Ȯ���غ��� 1~5 ���� ġ��� 1���� �㰡 �׷����ֽ��ϴ�."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko, 
            Dialog = new string[] {"", "�ֻ����� Ȯ���� �� ������ ī�带 �̽��ϴ�."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] {"", "�̰� ���� �������ΰ���?"}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] {"", "Ʋ�� ��� �ֻ����� ���� �� �ִ� �������Դϴ�."}},
        new Tutorial(){ id = 3, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me, 
            Dialog = new string[] {"", "������ �ֻ����� ���� ���ɼ��� ���ƺ��̴� �������� ����ּ���."}},
        new Tutorial(){ id = 4, tutorialType = TutorialType.SelectCard, characterType = CharacterType.Me, 
            Dialog = new string[] {"", ""}},
        new Tutorial(){ id = 5, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "�׷��� ���� ��밡 �� �������� Ȯ���� �� ���� �����ϰ� �˴ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me,
            Dialog = new string[] {"", "���� ����� �������� ������ �����Դϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Me,
            Dialog = new string[] {"", "�� �ֻ����� ���� ��� �ֻ����� ������ ����ϸ� �ǰڱ���"}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae,
            Dialog = new string[] {"", "���� �� ������"}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "���⼭ ���� ��ư�� ������ �� �������� Ȯ���ϰ�, �н� ��ư�� ������ ����� ������ ī�带 �̰� �˴ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "���� �������� ������ ��� �������� ���� ����� �ֻ����� �Ұ�, �������� ���� ��� ������ ����� �ֻ����� �ҽ��ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "�̷��� �������� ������ �ݺ��ϴ� ������ �ֻ����� �Ұ� ���� �ٽ� ��� �ֻ����� ������ ���� ������ �ݺ��ϰ� �˴ϴ�."}},
        new Tutorial(){ id = 6, tutorialType = TutorialType.Dialog, characterType = CharacterType.Bae,
            Dialog = new string[] {"", "�������� ����� ������ �� ������ �����غ���?"}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "Ư�� ���忡�� �������� ���� �� �ֽ��ϴ�."}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "�������� �̴� ����, ������ �ϴ� ���ȸ� �������� ����� �� �ֽ��ϴ�."}},
        new Tutorial(){ id = 7, tutorialType = TutorialType.Dialog, characterType = CharacterType.Hayko,
            Dialog = new string[] {"", "�����ۿ� ���콺�� ���� ��� ȿ���� �� �� �ְ� ���콺 Ŭ������ ����մϴ�."}},
    };
}
