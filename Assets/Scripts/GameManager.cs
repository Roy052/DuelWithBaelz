using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    None = 0,
    LoseDouble = 1,
    OneDice = 2,
}

public class GameManager : Singleton
{
    public GameMode mode = GameMode.None;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        if(gameManager == this)
            gameManager = null;
    }

    private void Start()
    {
        OptionList.SetOption();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
