using UnityEngine;
using System.Collections;

public class MineExplosion : MonoBehaviour
{
    public GameObject Mine;
    public bool exploded;
    public GameObject explosionEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        yield break;
    }
}
