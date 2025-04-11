using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public GameObject mainFirstButton;

    [Header("Panel First Buttons")]
    public GameObject optionsFirstButton;
    public GameObject cheatsFirstButton;
    public GameObject howToPlayFirstButton;
    public GameObject creditsFirstButton;
    public GameObject aboutFirstButton;

    [Header("Panel Close Buttons")]
    public GameObject optionsCloseButton;
    public GameObject cheatsCloseButton;
    public GameObject howToPlayCloseButton;
    public GameObject creditsCloseButton;
    public GameObject aboutCloseButton;

    [Header("UI Panels")]
    public GameObject mainMenuUI;
    public GameObject optionsUI;
    public GameObject cheatsUI;
    public GameObject howToPlayUI;
    public GameObject creditsUI;
    public GameObject aboutUI;

    void Start()
    {
        OpenMainMenu(); // Start on main menu
    }

    public void PlayGame()
    {
        // Timer.instance.ResetTimer(); // Uncomment when you implement timer
        SceneManager.LoadSceneAsync(1); // Load your first game scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // -------------------- PANEL OPEN FUNCTIONS --------------------

    public void OpenMainMenu()
    {
        mainMenuUI.SetActive(true);
        optionsUI.SetActive(false);
        cheatsUI.SetActive(false);
        howToPlayUI.SetActive(false);
        creditsUI.SetActive(false);
        aboutUI.SetActive(false);

        // Clear any previous focus and set the focus to the first button of the Main Menu
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    public void OpenOptions()
    {
        DeactivateAllPanels(); // Deactivate all panels
        optionsUI.SetActive(true); // Activate Options Panel

        // Clear focus and set focus to the first button of the Options UI
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void OpenCheats()
    {
        DeactivateAllPanels(); // Deactivate all panels
        cheatsUI.SetActive(true); // Activate Cheats Panel

        // Clear focus and set focus to the first button of the Cheats UI
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(cheatsFirstButton);
    }

    public void OpenHowToPlay()
    {
        DeactivateAllPanels(); // Deactivate all panels
        howToPlayUI.SetActive(true); // Activate How to Play Panel

        // Clear focus and set focus to the first button of the How to Play UI
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(howToPlayFirstButton);
    }

    public void OpenCredits()
    {
        DeactivateAllPanels(); // Deactivate all panels
        creditsUI.SetActive(true); // Activate Credits Panel

        // Clear focus and set focus to the first button of the Credits UI
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }

    public void OpenAbout()
    {
        DeactivateAllPanels(); // Deactivate all panels
        aboutUI.SetActive(true); // Activate About Panel

        // Clear focus and set focus to the first button of the About UI
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(aboutFirstButton);
    }

    // -------------------- PANEL CLOSE FUNCTIONS --------------------

    public void CloseOptions()
    {
        optionsUI.SetActive(false);
        OpenMainMenu(); // Go back to the Main Menu

        // Clear focus and set focus to the close button of the Options UI
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }

    public void CloseCheats()
    {
        cheatsUI.SetActive(false);
        OpenOptions(); // Go back to the Main Menu

        // Clear focus and set focus to the close button of the Cheats UI
        EventSystem.current.SetSelectedGameObject(cheatsCloseButton);
    }

    public void CloseHowToPlay()
    {
        howToPlayUI.SetActive(false);
        OpenAbout(); // Go back to the About UI

        // Clear focus and set focus to the close button of the How to Play UI
        EventSystem.current.SetSelectedGameObject(howToPlayCloseButton);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
        OpenAbout(); // Go back to the About UI

        // Clear focus and set focus to the close button of the Credits UI
        EventSystem.current.SetSelectedGameObject(creditsCloseButton);
    }

    public void CloseAbout()
    {
        aboutUI.SetActive(false);
        OpenMainMenu(); // Go back to the Main Menu

        // Clear focus and set focus to the close button of the About UI
        EventSystem.current.SetSelectedGameObject(aboutCloseButton);
    }

    // -------------------- HELPER FUNCTION --------------------
    private void DeactivateAllPanels()
    {
        // Deactivate all panels, except the current one being opened
        mainMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        cheatsUI.SetActive(false);
        howToPlayUI.SetActive(false);
        creditsUI.SetActive(false);
        aboutUI.SetActive(false);
    }
}