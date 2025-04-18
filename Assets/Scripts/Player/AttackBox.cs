using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public float timeActive = 0.1f;
    float timer;

    private void Start()
    {
        timer = timeActive;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(gameObject);
    }
}
