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
        if (other.tag == "AttackBox")
            Kill();
    }

    public void Kill()
    {
        if (GameManager.instance.IsItemLevel())
            DropItem();

        Destroy(gameObject);
    }

    private void DropItem()
    {
        if (Random.Range(0, 10) == 0)
        {
            Transform enemyLocation = gameObject.transform;
            //GameObject item = Instantiate(Enemy, enemyLocation)
        }      
    }
}
