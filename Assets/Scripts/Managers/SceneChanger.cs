using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    
    private void Awake()
    {
        instance = this;
    }

    public void ChangeScene(int scene)
    {
        //scene: 0 is reload current scene, 1 is main menu, 2 is hub, 3 sewer, 4 is alley, 5 is roof, 6 is win, 7 is loss
        switch (scene)
        {
            case 0:
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
                break;
            case 1:
                SceneManager.LoadSceneAsync("Main Menu");
                break;
            case 2:
                SceneManager.LoadSceneAsync("Hub");
                break;
            case 3:
                SceneManager.LoadSceneAsync("Sewer");
                break;
            case 4:
                SceneManager.LoadSceneAsync("Alley");
                break;
            case 5:
                SceneManager.LoadSceneAsync("Rooftops");
                break;
            case 6:
                SceneManager.LoadSceneAsync("Win Scene");
                break;
            case 7:
                SceneManager.LoadSceneAsync("Lose Scene");
                break;
            default:
                Debug.Log("Invalid Scene");
                break;
        }
    }
}
