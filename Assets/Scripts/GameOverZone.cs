using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            gameOverPanel.SetActive(true);
            GameOverController.instance.SetPauseGame(true);
            Debug.Log("Lose ;(");
        }
    }
}
