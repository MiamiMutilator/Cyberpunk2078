using UnityEngine;

public class LookAtPlayerRoamer : MonoBehaviour
{
    public Transform Player;

    void LateUpdate()
    {
        Vector3 targetPosition = Player.position;
        targetPosition.y = transform.position.y; 
        transform.LookAt(targetPosition);
    }
}
