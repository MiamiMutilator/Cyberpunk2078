using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScene : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
