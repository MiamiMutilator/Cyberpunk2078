using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public bool fired = false;
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

        if(Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }

        ThirdPersonMovement playerHealth = hit.transform.GetComponent<ThirdPersonMovement>();
        Debug.Log("Bang");

        if(playerHealth != null)
        {
            playerHealth.Damage(15);
        }
        else if (playerHealth == null)
        {
            fired = false;
            Debug.Log("Nothing");
        }
        StartCoroutine(shootCooldown());


    }

    IEnumerator shootCooldown()
    {
        yield return new WaitForSeconds(3);
        fired = false;
        yield break;

    }
}
