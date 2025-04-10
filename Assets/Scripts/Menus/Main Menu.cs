using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject mainFirst, optionsFirst, optionsClose, cheatsFirst, cheatsClose;

    void Start()
    {
        
    }
    
    public void PlayGame()
    {

        //Timer.instance.ResetTimer(); [this is for when timer is implemented uncomment this]
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
