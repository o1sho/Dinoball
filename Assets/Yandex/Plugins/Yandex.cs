using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [SerializeField] GameObject gameOverPanel;

    public void RateGameButton()
    {
        RateGame();
    }

    public void HelloButton()
    {
        Hello();
    }

    public void RewardAdvButton()
    {
        gameOverPanel.SetActive(false);
    }
}
