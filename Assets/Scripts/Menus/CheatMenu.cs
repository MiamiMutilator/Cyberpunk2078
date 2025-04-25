using UnityEngine;

public class CheatMenu : MonoBehaviour
{
    static bool infJump, infDash, invincible, doubleSpeed, timerDisabled;
    public static CheatMenu instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    [ContextMenu("Toggle Jump Cheat")]
    public void ToggleJumpCheat()
    {
        infJump = !infJump;
    }

    [ContextMenu("Toggle Invincibility Cheat")]
    public void ToggleInvincibilityCheat()
    {
        invincible = !invincible;
    }

    [ContextMenu("Toggle Dash Cheat")]
    public void ToggleDashCheat()
    {
        infDash = !infDash;
    }

    [ContextMenu("Toggle Speed Cheat")]
    public void ToggleSpeedCheat()
    {
        doubleSpeed = !doubleSpeed;

        if (GameManager.instance.IsPlayerLevel())
        {
            player.GetComponent<PlayerController>().HandleSpeedCheat();
        }
    }

    [ContextMenu("Toggle Timer Cheat")]
    public void ToggleTimerCheat()
    {
        timerDisabled = !timerDisabled;

        if (GameManager.instance.IsGameplayLevel())
        {
            Timer.instance.ToggleTimer(timerDisabled);
        }
    }

    public bool GetJumpCheatStatus()
    {
        return infJump;
    }

    public bool GetInvincibilityCheatStatus()
    {
        return invincible;
    }

    public bool GetDashCheatStatus()
    {
        return infDash;
    }

    public bool GetSpeedCheatStatus()
    {
        return doubleSpeed;
    }
    
    public bool GetTimerCheatStatus()
    {
        return timerDisabled;
    }
}