using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemManager : Singleton, IPointerExitHandler
{
    const int MaxAmmount = 4;

    public bool isPlayer;

    public GameObject objItem;
    public Tooltip tooltip;

    List<Item> items = new List<Item>();
    Vector3 pos = Vector3.zero;
    int currentItemCount = 0;

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
        if (currentItemCount >= MaxAmmount)
            return;

        if(currentItemCount >= items.Count)
        {
            GameObject temp = Instantiate(objItem, objItem.transform.parent);
            items.Add(temp.GetComponent<Item>());
        }

        Item tempItem = items[currentItemCount];
        tempItem.Set(type, this, currentItemCount);
        tempItem.SetActive(true);
        currentItemCount++;
    }

    public void UseItem(int idx)
    {
        if (isPlayer == false)
            return;

        if(idx >= currentItemCount)
        {
            Debug.LogError($"{idx} > {currentItemCount} Error");
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
                break;
            case ItemType.DiceofWitness:
                break;
        }

        items[idx].SetActive(false);
        currentItemCount--;
        tooltip.Hide();
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
        int itemIdx = Random.Range(0, currentItemCount);
        duelSM.NoticeEnemyItem(items[itemIdx].type);
        UseItem(itemIdx);
    }
}
