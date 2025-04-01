using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Text Objects")]
    public TMP_Text healthText;

    [Header("Game Variables")]
    public float gravity = 9.81f;
    public int maxHealth = 100;
    int health;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);

        //health = maxHealth;
        //healthText.text = "Health: " + health;
        //Debug.Log(health);
    }

    public void UpdateHealth(int amount)
    {
        health += amount;

        if (health > maxHealth) health = maxHealth;
        //if (health <= 0) kill player

        healthText.text = "Health: " + health;
        //Debug.Log(health);
    }
}
