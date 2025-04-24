using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupManager : MonoBehaviour
{
    public GameObject popup;
    public float displayDuration = 3f; //Timer

    void Start()
    {
        StartCoroutine(PopupSequence());
    }

    IEnumerator PopupSequence()
    {
        popup.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        popup.SetActive(false);
    }
}