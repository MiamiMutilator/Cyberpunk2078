using UnityEngine;

public class EnemyRangeTurret : MonoBehaviour
{
    private ShootTurret shootScript;

    //private LookAtPlayerInstant lookScript;

    private Animator anim;

    //public Transform Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lookScript = GetComponent<LookAtPlayerInstant>();
        shootScript = transform.parent.Find("Armature").GetComponent<ShootTurret>();
        anim = GetComponentInParent<Animator>();
        anim.SetBool("Idle", true);
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
            anim.SetBool("Shoot", true);
            anim.SetBool("Idle", false);
            //Vector3 targetPos = Player.position;
            //transform.LookAt(targetPos);
            //lookScript.GetComponent<LookAtPlayerInstant>().Player.LookAt(Player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<Shoot>().enabled = false;
            shootScript.enabled = false;
            anim.SetBool("Shoot", false);
            anim.SetBool("Idle", true);
        }
    }
}
