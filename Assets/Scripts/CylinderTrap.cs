using UnityEngine;

public class CylinderTrap : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool activated = false;

    public float speed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision collision)
    {
        //ativar ao ser atingido pela bala
        if (collision.gameObject.CompareTag("Bullet") && !activated)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null)
            {
                //calcula direção UMA VEZ
                moveDirection = (playerObj.transform.position - transform.position).normalized;
                activated = true;

                Invoke("StopMoving", 3.0f);
            }
        }

        //matar player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();

            if (p != null)
            {
                p.Die();
            }
        }
    }

    void FixedUpdate()
    {
        if (activated)
        {
            rb.linearVelocity = moveDirection * speed;
        }
    }

    void StopMoving()
    {
        rb.linearVelocity = Vector3.zero;
        activated = false;
    }
}