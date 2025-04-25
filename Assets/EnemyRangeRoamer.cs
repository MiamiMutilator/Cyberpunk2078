using UnityEngine;

public class EnemyRangeRoamer : MonoBehaviour
{
    private ShootTurret shootScript;

    //private LookAtPlayerInstant lookScript;

    private Animator anim;

    private AudioSource audioSource;


    //public Transform Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lookScript = GetComponent<LookAtPlayerInstant>();
        shootScript = GetComponentInParent<ShootTurret>();
        anim = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
            audioSource.Play();
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
