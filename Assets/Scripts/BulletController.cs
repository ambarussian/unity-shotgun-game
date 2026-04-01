using UnityEngine;

public class BulletController : MonoBehaviour
{

    void OnCollisionEnter (Collision collision)
    {
        Destroy(collision.gameObject);
        float randomX = UnityEngine.Random.Range(-20,20);
        float randomZ = UnityEngine.Random.Range(-20,20);
        GameObject enemy = Instantiate(Resources.Load("Enemy",
                                                      typeof(GameObject)
                                                      )) as GameObject;
        enemy.transform.position = new Vector3(randomX, 1, randomZ);
        enemy.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);
        Destroy(gameObject);
    }
}
