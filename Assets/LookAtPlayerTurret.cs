using UnityEngine;

public class LookAtPlayerTurret : MonoBehaviour
{
    public Transform Player;
    public Transform tripod;
    private Quaternion tripodWorldRotation;
    //private Quaternion tripodInitialRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(Player);
        tripodWorldRotation = tripod.rotation;
        //tripodInitialRotation = tripod.localRotation;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //transform.LookAt(Player);
    //    Vector3 targetPos = Player.position;
    //    targetPos.y = transform.position.y;
    //    transform.LookAt(targetPos);
    //}

    void LateUpdate()
    {
        Vector3 targetPosition = Player.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
        //transform.LookAt(Player);
        //Vector3 targetPos = Player.position;
        //targetPos.y = transform.position.y;
        //transform.LookAt(targetPos);
        //tripod.localRotation = tripodInitialRotation;
        tripod.rotation = tripodWorldRotation;
    }
}
