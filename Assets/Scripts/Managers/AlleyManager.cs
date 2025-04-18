using UnityEngine;

public class AlleyManager : MonoBehaviour
{

    public GameObject bossRef;
    public GameObject exitColl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitColl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossRef == null)
        {
            exitColl.SetActive(true);
        }
    }
}
