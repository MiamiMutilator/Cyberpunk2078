using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialOpen : MonoBehaviour
{
    // Reference to the tutorial GameObject
    public GameObject Tutorial;

    // Method to open the tutorial
    public void OpenTutorial()
    {
        // Check if the Tutorial object is not null
        if (Tutorial != null)
        {
            // Activate the tutorial panel
            Tutorial.SetActive(true);
        }
    }
}