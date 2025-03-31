using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TMP_Text timerText;
    static float timer;
    public float timerLength = 60;
    bool timerActive;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (timer <= 0) ResetTimer();
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerActive) return;
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");

        if (timer < 0)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
    
    public void ResetTimer()
    {
        timer = timerLength;
    }

    public void DisableTimer()
    {
        timerActive = false;
    }
}
