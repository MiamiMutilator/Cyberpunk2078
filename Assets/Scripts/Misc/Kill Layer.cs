using UnityEngine;
using UnityEngine.SceneManagement;

public class KillLayer : MonoBehaviour
{
     public GameObject player;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerController.instance.ChangeHealth(false); [this is 2DRemix code might use later idk]
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

}
