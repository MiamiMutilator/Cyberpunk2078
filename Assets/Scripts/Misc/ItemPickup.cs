using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.ItemCollect();
        Destroy(gameObject);
    }
}
