using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int StartY;
    public int EndY;

    RectTransform rect;
    Coroutine current = null;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnEnable()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, StartY);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (current != null)
            StopCoroutine(current);

        current = StartCoroutine(FadeManager.MoveRectTransform(rect, rect.anchoredPosition, new Vector2(rect.anchoredPosition.x, EndY), 0.3f));
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (current != null)
            StopCoroutine(current);

        current = StartCoroutine(FadeManager.MoveRectTransform(rect, rect.anchoredPosition, new Vector2(rect.anchoredPosition.x, StartY), 0.3f));
    }
}
