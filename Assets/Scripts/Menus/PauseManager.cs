using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{

    public GameObject pauseFirstButton, HowtoplayFirstButton, HowtoplayClosedButton;

    private bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject howtoplayUI;
    public GameObject creditsUI;
    GameObject player, reticle;
    AudioSource enemyAudio;

    KeyCode pauseKeyboard = KeyCode.P;
    KeyCode pauseController = KeyCode.JoystickButton7;

    //public GameObject pauseFirst

    void Start()
    {
        player = GameObject.Find("Player");
        //pauseMenuUI.SetActive(false);
        //reticle = GameObject.Find("Reticle");
        ResumeGame();
    }

    void Update()
    {
        if (PauseButtonCheck())
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuUI.SetActive(true);
        player.SetActive(false);
        //PlayerMovement.instance.SetPlayerStatus(false);
        //reticle.SetActive(false);
        
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false);
        player.SetActive(true);
        //PlayerMovement.instance.SetPlayerStatus(true);
        //reticle.SetActive(true);
        
    }

    bool PauseButtonCheck()
    {
        if (Input.GetKeyDown(pauseKeyboard) || Input.GetKeyDown(pauseController))
            return true;
        return false;
    }
}