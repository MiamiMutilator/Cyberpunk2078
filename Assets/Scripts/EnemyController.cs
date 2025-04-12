using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    private void Start()
    {
        /* levelname is placeholder, replace with the name of the level where you collect items to complete
        if (SceneManager.GetActiveScene().name == levelname)
            itemLevel = true;
        */
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
            Kill();
        }
    }

    public void Kill()
    {
        if (GameManager.instance.IsItemLevel())
            DropItem();

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
