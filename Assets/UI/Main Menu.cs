using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    public void PlayGame()
    {
        //Timer.instance.ResetTimer(); [this is for when timer is implemented uncomment this]
        //SceneManager.LoadSceneAsync(1); [this is to load first scene when we make that uncomment this]
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
