using UnityEngine;

public class ItemFloat : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bobSpeed = 2f;
    public float bobHeight = 0.25f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Spin
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Bob
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
