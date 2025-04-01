using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    bool enemyFound = false;
    public GameObject pauseMenuUI;
    public GameObject howtoplayUI;
    public GameObject creditsUI;
    GameObject player, reticle;
    AudioSource enemyAudio;

    void Start()
    {
        player = GameObject.Find("New Player");
        //pauseMenuUI.SetActive(false);
        reticle = GameObject.Find("Reticle");
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                ResumeGame(); 
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                PauseGame();
            }
        }
        if (pauseMenuUI.activeInHierarchy == false)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuUI.SetActive(true);
        player.SetActive(false);
        if (enemyFound) enemyAudio.Pause();
        //PlayerMovement.instance.SetPlayerStatus(false);
        reticle.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false);
        player.SetActive(true);
        if (enemyFound) enemyAudio.Play();
        //PlayerMovement.instance.SetPlayerStatus(true);
        reticle.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void FindEnemy()
    {
        enemyAudio = GameObject.Find("Enemy").GetComponent<AudioSource>();
        enemyFound = true;
    }
}