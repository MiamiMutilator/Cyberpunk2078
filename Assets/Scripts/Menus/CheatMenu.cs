using UnityEngine;

public class CheatMenu : MonoBehaviour
{
    static bool infJump, infDash, invincible, doubleSpeed;
    public static CheatMenu instance;

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

        if (GameManager.instance.IsGameplayLevel())
        {
            GameObject.Find("Player").GetComponent<PlayerController>().HandleSpeedCheat();
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
}