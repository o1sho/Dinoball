using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
        Time.timeScale = 1.0f;
    }
}
