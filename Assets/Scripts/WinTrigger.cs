using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.instance.IsItemLevel())
            {
                if (!GameManager.instance.HasEnoughItems())
                    return;
            }
            
            GameManager.instance.CompleteLevel();
        }
    }
}
