using UnityEngine;

public class TeleportTrap : MonoBehaviour
{
    public float range = 20.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float randomX = Random.Range(-range, range);
            float randomZ = Random.Range(-range, range);

            Vector3 newPosition = new Vector3(randomX, 1, randomZ);

            other.transform.position = newPosition;
        }
    }
}