using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCursorMove : MonoBehaviour
{
    public bool isVertical;
    public int value;

    RectTransform rt;
    float moveTime = 1f;
    float currentTime = 0f;
    bool direction = false;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(rt != null)
        {
            if (currentTime >= moveTime)
            {
                direction = !direction;
                currentTime = 0f;
            }

            rt.anchoredPosition += new Vector2(0, (direction ? 1 : -1) * value * Time.deltaTime);
            currentTime += Time.deltaTime;
        }
    }
}
