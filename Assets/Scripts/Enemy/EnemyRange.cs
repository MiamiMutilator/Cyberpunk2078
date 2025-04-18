using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    private Shoot shootScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootScript = GetComponentInParent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (InRange == true)
        //{
        //    GetComponent<Shoot>().enabled = true;
        //    InRange = false;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<Shoot>().enabled = true;
            shootScript.enabled = enabled;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<Shoot>().enabled = false;
            shootScript.enabled = false;

        }
    }
}
