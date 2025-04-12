using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Text Objects")]
    public TMP_Text healthText;

    [Header("Game Variables")]
    public float gravity = 9.81f; //default value, refer to inspector for current value
    public int maxHealth = 100; //default value, refer to inspector for current value
    public int health;
    static bool sewerComplete, alleyComplete, roofComplete;
    int itemCount = 0;
    public int ItemsNeeded = 10;

    int levelNumber; //sewer is level 1, alley is level 2, roof is level 3
    int sceneType; //1 is main menu, 2 is hub, 3 gameplay, 4 is win/loss
    GameObject sewerLight, alleyLight, roofLight;

    [Header("Item UI")]
    public TMP_Text itemCountText;
    public TMP_Text warningText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    { 
        SceneCheck();
        StartScene();

        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    public void UpdateHealth(int amount)
    {
        health += amount;

        if (health > maxHealth) health = maxHealth;
        if (health <= 0) KillPlayer();

        //healthText.text = "Health: " + health;
        Debug.Log(health);
    }

    void SceneCheck()
    {
        string currentScene =  SceneManager.GetActiveScene().name;
        levelNumber = -1;
        sceneType = -1;

        //switch statement based on scene name for handling update of scene specific values
        //level number: sewer is level 1, alley is level 2, roof is level 3
        //scene type: 1 is main menu, 2 is hub, 3 gameplay, 4 is win/loss
        switch (currentScene)
        {
            case "Main Menu":
                levelNumber = 0;
                sceneType = 1;
                break;
            case "Hub":
                levelNumber = 0;
                sceneType = 2;
                break;
            case "Sewer":
                levelNumber = 1;
                sceneType = 3;
                break;
            case "Alley":
                levelNumber = 2;
                sceneType = 3;
                break;
            case "Rooftops":
                levelNumber = 3;
                sceneType = 3;
                break;
            case "Win Scene":
            case "Lose Scene":
                levelNumber = 0;
                sceneType = 4;
                break;
            default:
                Debug.Log("Scene Name not found");
                break;
        }
    }

    void StartScene()
    {
        //scene type: 1 is main menu, 2 is hub, 3 gameplay, 4 is win/loss
        switch (sceneType)
        {
            case -1:
                Debug.Log("Failed to set Scene Type");
                break;
            case 1:
                MainMenuStart();
                break;
            case 2:
                HubStart();
                break;
            case 3:
                GameplayStart();
                break;
            case 4:
                WinLossStart();
                break;
            default:
                Debug.Log("Invalid Level Type");
                break;
        }

    }

    void MainMenuStart()
    {
        //perform main menu setup actions
    }
    void HubStart()
    {
        //get gameobjects of all lights
        sewerLight = GameObject.Find("Sewer Light");
        alleyLight = GameObject.Find("Sewer Light");
        roofLight = GameObject.Find("Sewer Light");

        //update lights
        if (sewerComplete)
            sewerLight.GetComponent<Renderer>().material.color = Color.green;
        if (alleyComplete)
            alleyLight.GetComponent<Renderer>().material.color = Color.green;
        if (roofComplete)
            roofLight.GetComponent<Renderer>().material.color = Color.green;
    }

    void GameplayStart()
    {
        health = maxHealth;
        //healthText.text = "Health: " + health;
        Debug.Log(health);
    }

    void WinLossStart()
    {
        //perform win/loss scene setup actions
    }

    public void ItemCollect()
    {
        itemCount++;
        UpdateItemUI();
        Debug.Log("Item Count: " + itemCount);
    }

    private void UpdateItemUI()
    {
        if (itemCountText != null)
            itemCountText.text = $"Items: {itemCount}/{ItemsNeeded}";
    }

    public void CompleteLevel()
    {
        //sewer is level 1, alley is level 2, roof is level 3
        switch (levelNumber)
        {
            case -1:
                Debug.Log("Failed to set Level Number");
                break;
            case 0:
                Debug.Log("Selected Level is not a gameplay level");
                break;
            case 1:
                sewerComplete = true;
                break;
            case 2:
                alleyComplete = true;
                break;
            case 3:
                roofComplete = true;
                break;
            default:
                Debug.Log("Invalid Level");
                break;
        }

        SceneChanger.instance.ChangeScene(6); //swap to 2 once hub world is implemented
    }

    public bool IsItemLevel()
    {
        if (levelNumber == 3)
            return true;
        return false;
    }

    public bool HasEnoughItems()
    {
        return itemCount >= ItemsNeeded;
    }

    void KillPlayer()
    {
        SceneChanger.instance.ChangeScene(0);
    }
    
    public bool isSewerComplete()
    {
        return sewerComplete;
    }

    public bool isAlleyComplete()
    {
        return alleyComplete;
    }

    public bool isRoofComplete()
    {
        return roofComplete;
    }
}
