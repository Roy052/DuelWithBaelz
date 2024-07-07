using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemManager : Singleton, IPointerExitHandler
{
    const int MaxAmmount = 4;

    public bool isPlayer;
    public int itemCount
    {
        get { return items.Count; }
    }

    public GameObject objItem;
    public Tooltip tooltip;
    public GameObject objSelectDiceCover;

    List<Item> items = new List<Item>();
    Vector3 pos = Vector3.zero;

    private void Start()
    {
        //AddItem(ItemType.MagnifyingGlass);
        //AddItem(ItemType.WoodDice);
        //AddItem(ItemType.SharkTeeth);
        //AddItem(ItemType.Watch);

        pos = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void AddItem(ItemType type)
    {
        if (items.Count >= MaxAmmount) 
            return;

        GameObject temp = Instantiate(objItem, objItem.transform.parent);
        Item tempItem = temp.GetComponent<Item>();
        tempItem.Set(type, this, items.Count);
        tempItem.SetActive(true);
        items.Add(tempItem);
    }

    public void UseItem(int idx, bool isEnemy = false)
    {
        if (isEnemy == false && (duelSM.gameState != GameState.InChoice && duelSM.gameState != GameState.InDecision))
            return;

        //if (isEnemy && duelSM.gameState != GameState.BaelzThinking)
        //    return;

        if(idx >= items.Count)
        {
            Debug.LogError($"{idx} > {items.Count} Error");
            return;
        }
        switch (items[idx].type)
        {
            case ItemType.MagnifyingGlass:
                duelSM.CheckEnemyDice(isPlayer, 1);
                break;
            case ItemType.WoodDice:
                if (duelSM.gameState == GameState.InJudge)
                    return;
                duelSM.AddDice(isPlayer, 1);
                break;
            case ItemType.SharkTeeth:
                duelSM.AddDamage(1);
                break;
            case ItemType.Watch:
                duelSM.SelectRollDice();
                break;
            case ItemType.DiceofWitness:
                break;
        }

        tooltip.Hide();

        duelSM.NoticeItemUse(isPlayer, items[idx].type);
        Destroy(items[idx].gameObject);
        items.RemoveAt(idx);
    }

    public void UseItemToClick(int idx)
    {
        if (isPlayer == false)
            return;

        UseItem(idx);
    }

    public void Reset()
    {
        while(items.Count > 0)
        {
            Destroy(items[0].gameObject);
            items.RemoveAt(0);
        }
        tooltip.Hide();
    }

    private void Update()
    {
        if (Mathf.Abs(Input.mousePosition.x - pos.x) > 160)// || Mathf.Abs(Input.mousePosition.y - pos.y) > 160)
            tooltip.Hide();
        //Debug.Log($"{(int)Mathf.Abs(Input.mousePosition.x - pos.x)}, {(int)Mathf.Abs(Input.mousePosition.y - pos.y)}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //var 
        //Debug.Log(I);
        

    }

    public void UseRandomItem()
    {
        int itemIdx = Random.Range(0, items.Count);
        duelSM.NoticeItemUse(isPlayer, items[itemIdx].type);
        UseItem(itemIdx, true);
    }
}
