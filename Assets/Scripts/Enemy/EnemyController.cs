using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 1;
    int health;
    public GameObject itemPrefab; //lucas added this for item model

    public bool isDead = false;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AttackBox")
            Kill();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            ChangeHealth(-1);
            Debug.Log("collision");
        }
    }

    void ChangeHealth(int amount)
    {
        health += amount;

        if (health <= 0)
            Kill();
    }

    public void Kill()
    {
        if (GameManager.instance.IsItemLevel())
            DropItem();

        Debug.Log("Kill function ran");
        isDead = true;
        Destroy(gameObject);
    }

    private void DropItem()
    {
        if (Random.Range(0, 10) >= 0)
        {
            Vector3 enemyLocation = gameObject.transform.position + Vector3.up * 1f;
            //GameObject item = Instantiate(Enemy, enemyLocation)

            GameObject item = Instantiate(itemPrefab, enemyLocation, Quaternion.identity);
            
            /*GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = enemyLocation;
            sphere.GetComponent<Collider>().isTrigger = true;
            sphere.AddComponent<ItemPickup>();*/
        }      
    }
}
