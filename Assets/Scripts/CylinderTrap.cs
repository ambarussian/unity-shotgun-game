using UnityEngine;

public class CylinderTrap : MonoBehaviour
{
    private Transform player;
    private bool activated = false;

    public float speed = 5f;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            activated = true;
        }
    }

    void Update()
    {
        if (activated && player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Die();
            }
        }
    }
}