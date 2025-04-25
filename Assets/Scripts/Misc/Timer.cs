using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TMP_Text timerText;
    static float timer;
    public float timerLength = 60;
    bool timerDisabled;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //if (timer <= 0) ResetTimer();   //uncomment if choosing to not reset timer on death
        ResetTimer();
    }

    void Update()
    {
        if (timerDisabled) return;
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");

        if (timer <= 0)
        {
            timer = 0;
            timerDisabled = true;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            // SceneChanger.instance.ChangeScene(7); //change to 2 once hub level is created
        }
    }
    
    public void ResetTimer()
    {
        timer = timerLength;
    }

    public void DisableTimer()
    {
        timerDisabled = true;
    }

    public void ToggleTimer(bool status)
    {
        timerDisabled = status;
    }
}
