using UnityEngine;

public class CheatMenu : MonoBehaviour
{
    static bool infAmmoStatus, invincibilityStatus;
    public static CheatMenu instance;

    private void Awake()
    {
        instance = this;
    }

    // This method toggles the speed cheat on and off.
    public void ToggleAmmoCheat()
    {
        infAmmoStatus = !infAmmoStatus;
    }

    public void ToggleInvincibilityCheat()
    {
        invincibilityStatus = !invincibilityStatus;
    }

    public bool GetAmmoCheatStatus()
    {
        return infAmmoStatus;
    }

    public bool GetInvincibilityCheatStatus()
    {
        return invincibilityStatus;
    }
}