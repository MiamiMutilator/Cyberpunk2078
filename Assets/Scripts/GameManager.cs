using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float gravity = 9.81f;

    private void Start()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
    }
}
