using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 1;
    int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "AttackBox")
        //    Kill();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AttackBox"))
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
        Destroy(gameObject);
    }

    private void DropItem()
    {
        if (Random.Range(0, 10) >= 0)
        {
            Vector3 enemyLocation = gameObject.transform.position;
            //GameObject item = Instantiate(Enemy, enemyLocation)

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = enemyLocation;
            sphere.GetComponent<Collider>().isTrigger = true;
            sphere.AddComponent<ItemPickup>();
        }      
    }
}
