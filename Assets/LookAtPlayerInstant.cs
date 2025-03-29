using UnityEngine;

public class LookAtPlayerInstant : MonoBehaviour
{
    public Transform Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(Player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
    }
}
