using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZoneSewer : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            SceneManager.LoadSceneAsync("Sewer");
        }
    }
}
