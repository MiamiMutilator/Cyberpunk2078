using UnityEngine;
using UnityEngine.UI;

public class CheatUIStartCheck : MonoBehaviour
{
    public Image jumpUI, dashUI, invinUI, speedUI, timerUI;

    private void Start()
    {
        if (GameManager.instance.IsPlayerLevel())
        {
            if (CheatMenu.instance.GetJumpCheatStatus()) jumpUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetDashCheatStatus()) dashUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetSpeedCheatStatus()) invinUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetSpeedCheatStatus()) speedUI.gameObject.SetActive(true);
            if (CheatMenu.instance.GetTimerCheatStatus()) timerUI.gameObject.SetActive(true);
        }
        
        
    }
}
