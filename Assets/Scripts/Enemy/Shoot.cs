using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public bool fired = false;
    public int fireCooldown = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        fired = false;
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
        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100f))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }

        PlayerController playerHealth = hit.transform.GetComponent<PlayerController>();
        //Debug.Log("Bang");

        if(playerHealth != null)
        {
            playerHealth.Damage(-15);
            //GameManager.instance.UpdateHealth(-15);
        }
        else if (playerHealth == null)
        {
            fired = true;
            //Debug.Log("Nothing");
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
