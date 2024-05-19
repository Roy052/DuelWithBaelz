using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipHideZone : MonoBehaviour, IPointerExitHandler
{
    public Tooltip tooltip;

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Hide();
    }
}
