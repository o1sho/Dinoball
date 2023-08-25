using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject textGameOver;

    private void Start()
    {
        textGameOver.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        PlayerController.instance.SetStatusPlayer(false);
        SoundsController.instance.deathSound.Play();
        textGameOver.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        textGameOver.SetActive(false);
        gameOverPanel.SetActive(true);
        GameOverController.instance.SetPauseGame(true);
        Debug.Log("Lose ;(");
    }
}
