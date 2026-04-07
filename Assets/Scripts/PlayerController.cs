using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation
        );

        AudioSource shoot = GetComponent<AudioSource>();
        shoot.Play();

        //bullet.GetComponent<Rigidbody>().linearVelocity() = bullet.transform.forward * 6f;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bullet.transform.forward * 6f;
        Destroy(bullet, 3f);
    }
}
