using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundsController.instance.buttonSound.Play();
    }

    public void LoadScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
        Time.timeScale = 1.0f;
        SoundsController.instance.buttonSound.Play();
    }
}
