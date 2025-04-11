using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseFirstButton;
    public GameObject howtoplayFirstButton, howtoplayClosedButton;
    public GameObject creditsFirstButton, creditsClosedButton;
    public GameObject cheatsFirstButton, cheatsClosedButton;

    public GameObject pauseMenuUI;
    public GameObject howtoplayUI;
    public GameObject creditsUI;
    public GameObject cheatsUI;

    private bool isPaused = false;

    GameObject player;

    KeyCode pauseKeyboard = KeyCode.P;
    KeyCode pauseController = KeyCode.JoystickButton7;

    void Start()
    {
        player = GameObject.Find("Player");
        ResumeGame();
    }

    void Update()
    {
        if (PauseButtonCheck())
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;

        pauseMenuUI.SetActive(true);
        howtoplayUI.SetActive(false);
        creditsUI.SetActive(false);
        cheatsUI.SetActive(false);

        player.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;

        pauseMenuUI.SetActive(false);
        howtoplayUI.SetActive(false);
        creditsUI.SetActive(false);
        cheatsUI.SetActive(false);

        player.SetActive(true);
    }

    bool PauseButtonCheck()
    {
        return Input.GetKeyDown(pauseKeyboard) || Input.GetKeyDown(pauseController);
    }

    // -------------------- PANEL OPEN FUNCTIONS --------------------

    public void OpenHowToPlay()
    {
        pauseMenuUI.SetActive(false);
        howtoplayUI.SetActive(true);
        creditsUI.SetActive(false);
        cheatsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(howtoplayFirstButton);
    }

    public void OpenCredits()
    {
        pauseMenuUI.SetActive(false);
        howtoplayUI.SetActive(false);
        creditsUI.SetActive(true);
        cheatsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }

    public void OpenCheats()
    {
        pauseMenuUI.SetActive(false);
        howtoplayUI.SetActive(false);
        creditsUI.SetActive(false);
        cheatsUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(cheatsFirstButton);
    }

    // -------------------- PANEL CLOSE FUNCTIONS --------------------

    public void CloseHowToPlay()
    {
        howtoplayUI.SetActive(false);
        pauseMenuUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(howtoplayClosedButton);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
        pauseMenuUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsClosedButton);
    }

    public void CloseCheats()
    {
        cheatsUI.SetActive(false);
        pauseMenuUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(cheatsClosedButton);
    }
}