using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : Singleton
{
    public Sprite[] sideSprites;
    public Sprite[] typeSprites;
    public Sprite[] portraitSprites;
    public Sprite[] itemSprites;

    private void Awake()
    {
        if (imageManager == null)
            imageManager = this;
        else
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if(imageManager == this)
            imageManager = null;
    }
}
