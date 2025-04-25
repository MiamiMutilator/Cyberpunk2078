using UnityEngine;
using UnityEngine.UI;

public class CheatUIStartCheck : MonoBehaviour
{
    public Image jumpUI, dashUI, invinUI, speedUI, timerUI;

    private void Start()
    {
        //Debug.Log("Started Cheat UI Check");
        if (GameManager.instance.IsPlayerLevel())
        {
            if (CheatMenu.instance.GetJumpCheatStatus()) jumpUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetDashCheatStatus()) dashUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetInvincibilityCheatStatus()) invinUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetSpeedCheatStatus()) speedUI.gameObject.SetActive(true);
            //Debug.Log("Is Player Level and Checked Cheat UI");
        }
        
        
    }
}
