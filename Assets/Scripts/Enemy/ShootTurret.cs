using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootTurret : MonoBehaviour
{
    public Transform FirePoint;
    public bool fired = false;
    public int fireCooldown = 3;

    private Transform player; // Reference to the player Transform

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fired = false;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Automatically get the player (make sure the player has the "Player" tag)
    }

    // Update is called once per frame
    void Update()
    {
        if (fired == false)
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        fired = true;

        
        Vector3 directionToPlayer = (player.position - FirePoint.position).normalized;

        RaycastHit hit;
        Debug.DrawRay(FirePoint.position, directionToPlayer * 100f, Color.red); 

        // Shoot ray toward player
        if (Physics.Raycast(FirePoint.position, directionToPlayer, out hit, 100f))
        {
            // Check if we hit the player
            PlayerController playerHealth = hit.transform.GetComponent<PlayerController>();

            if (playerHealth != null)
            {
                playerHealth.Damage(-15); // Deal damage to player
                //GameManager.instance.UpdateHealth(-15);
            }
        }

        StartCoroutine(shootCooldown());
    }

    IEnumerator shootCooldown()
    {
        yield return new WaitForSeconds(fireCooldown);
        fired = false;
        yield break;
    }
}