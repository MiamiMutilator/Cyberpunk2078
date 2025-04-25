using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour
{
    public GameObject Mine;
    public bool exploded;
    public GameObject explosionEffect;
    private Animator anim;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetBool("MouseIdle", true);
        exploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mine == null && exploded == false)
        {
            audioSource.Play();
            exploded = true;
            explosionEffect.SetActive(true);
            StartCoroutine(Wait());

        }
    }

    


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);
        yield break;
    }
}
