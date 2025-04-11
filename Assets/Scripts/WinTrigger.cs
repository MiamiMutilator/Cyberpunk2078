using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    public float warningDuration = 3f;    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.instance.IsItemLevel())
            {
                if (!GameManager.instance.HasEnoughItems())
                {
                    ShowWarning("Not Enough Items Collected!");
                    return;
                }
            }
            
            GameManager.instance.CompleteLevel();
        }
    }

     private void ShowWarning(string message)
    {
        if (GameManager.instance.warningText != null)
        {
            GameManager.instance.warningText.text = message;
            GameManager.instance.warningText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideWarning));
            Invoke(nameof(HideWarning), warningDuration);
        }
    }

    private void HideWarning()
    {
        if (GameManager.instance.warningText != null)
        {
            GameManager.instance.warningText.gameObject.SetActive(false);
        }
    }

}
