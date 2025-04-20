using UnityEngine;
using UnityEngine.AI;

public class EnemyRangeMine : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent enemy;
    private bool followingPlayer = false;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GetComponentInParent<NavMeshAgent>();
        followingPlayer = false;
        anim = GetComponentInParent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer == true)
        {
            enemy.destination = player.position;
            anim.SetBool("MouseIdle", false);
            anim.SetBool("MouseWalk", true);


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            followingPlayer = true;
        }
    }

    
}
