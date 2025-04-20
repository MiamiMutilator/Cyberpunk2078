using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour
{
    public GameObject Mine;
    public bool exploded;
    public GameObject explosionEffect;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("MouseIdle", true);
        exploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mine == null && exploded == false)
        {
            exploded = true;
            explosionEffect.SetActive(true);
            StartCoroutine(Wait());

        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield break;
    }
}
