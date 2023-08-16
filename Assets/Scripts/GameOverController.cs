using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameOverController : MonoBehaviour
{
    public static GameOverController instance;

    [SerializeField] private GameObject gameOverPanel;

    //[SerializeField] private bool gameIsPause;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        //gameIsPause = false;
    }

    public void SetPauseGame(bool gameIsPause)
    {
        if (gameIsPause)
        {
            Time.timeScale = 0f;
            gameIsPause= true;
        } else Time.timeScale = 1.0f;
    }
}
