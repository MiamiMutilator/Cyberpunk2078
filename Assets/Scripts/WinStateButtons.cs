using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateButtons : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}