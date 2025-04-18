using UnityEngine;
using System.Collections;

public class MouseMine : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            explosion();
        }
    }

    //public PlayerController playerHealth;
    
    public void explosion()
    {
        GameManager.instance.UpdateHealth(-50);
        //playerHealth.Damage(50);
        Destroy(gameObject);
    }

    
}
