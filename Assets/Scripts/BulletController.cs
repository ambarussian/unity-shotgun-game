using UnityEngine;

public class BulletController : MonoBehaviour
{
    public PlayerController player;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            //soma ponto
            if (player != null)
            {
                player.AddScore();
            }

            //respawn inimigo
            float randomX = Random.Range(-20, 20);
            float randomZ = Random.Range(-20, 20);

            GameObject enemy = Instantiate(
                Resources.Load("Enemy", typeof(GameObject))
            ) as GameObject;

            enemy.transform.position = new Vector3(randomX, 1, randomZ);
            enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            Destroy(gameObject);
        }
    }
}