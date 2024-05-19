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
        items.Add(tempItem);
        temp.SetActive(true);
    }

    public void UseItem(int idx)
    {
        switch (items[idx].type)
        {
            case ItemType.MagnifyingGlass:
                break;
            case ItemType.WoodDice:
                if (duelSM.gameState == GameState.InJudge)
                    return;
                duelSM.AddDice(isPlayer, 1);
                break;
            case ItemType.SharkTeeth:
                break;
            case ItemType.Watch:
                break;
            case ItemType.DiceofWitness:
                break;
        }
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
}
