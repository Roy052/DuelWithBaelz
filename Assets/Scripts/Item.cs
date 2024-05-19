using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemType
{
    MagnifyingGlass,
    WoodDice,
    SharkTeeth,
    Watch,
    DiceofWitness,
}

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [NonSerialized]public ItemType type; 
    [NonSerialized]public ItemManager itemManager;
    [NonSerialized]public int idx;

    public Image imgItem;

    public void Set(ItemType type, ItemManager itemManager, int idx)
    {
        this.type = type;
        this.itemManager = itemManager;
        this.idx = idx;

        imgItem.sprite = Singleton.imageManager.itemSprites[(int)type];
    }

    public void OnClickUse()
    {
        itemManager.UseItem(idx);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        RectTransform rect = this.transform as RectTransform;
        itemManager.tooltip.Setitem(type);
        itemManager.tooltip.rect.anchoredPosition = new Vector2(0, itemManager.GetComponent<RectTransform>().anchoredPosition.y + rect.anchoredPosition.y);
        itemManager.tooltip.Show();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        itemManager.UseItem(idx);
    }
}
