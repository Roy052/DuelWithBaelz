using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingBox : MonoBehaviour
{
    public GameObject[] objDots;
    WaitForSeconds delay = new WaitForSeconds(0.33f);

    public IEnumerator Show()
    {
        Hide();

        this.SetActive(true);

        foreach (GameObject obj in objDots)
        {
            yield return delay;
            obj.SetActive(true);
        }

        yield return delay;
        this.SetActive(false);
    }

    public void Hide()
    {
        foreach (GameObject obj in objDots)
            obj.SetActive(false);
    }
}
