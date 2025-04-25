using UnityEngine;
using UnityEngine.UI;

public class ToggleCheckmark : MonoBehaviour
{
    
    public Image checkmarkImage; // Reference to the checkmark Image
    public Image uiImage; //UI Indicator for Cheat
    private bool isChecked = false; // Keeps track of whether the checkmark is enabled
    public bool jumpCheck, dashCheck, invinCheck, speedCheck, timerCheck;

    void Start()
    {
        if (jumpCheck)
        {
            if (CheatMenu.instance.GetJumpCheatStatus()) ToggleCheckmarkVisibility();
        }
        else if (dashCheck)
        {
            if (CheatMenu.instance.GetDashCheatStatus()) ToggleCheckmarkVisibility();
        }
        else if (invinCheck)
        {
            if (CheatMenu.instance.GetSpeedCheatStatus()) ToggleCheckmarkVisibility();
        }
        else if (speedCheck)
        {
            if (CheatMenu.instance.GetSpeedCheatStatus()) ToggleCheckmarkVisibility();
        }
        else if (timerCheck)
        {
            if (CheatMenu.instance.GetTimerCheatStatus()) ToggleCheckmarkVisibility();
        }
    }

    // This method will be called when the button is clicked
    public void ToggleCheckmarkVisibility()
    {
        isChecked = !isChecked; // Toggle the state
        checkmarkImage.gameObject.SetActive(isChecked); // Enable or disable the checkmark
        uiImage.gameObject.SetActive(isChecked); //Enable or disable the UI indicator for Cheat
    }
    
}
