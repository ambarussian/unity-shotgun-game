using UnityEngine;

public class KillerTrap : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}