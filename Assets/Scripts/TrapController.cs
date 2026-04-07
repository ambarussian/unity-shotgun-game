using UnityEngine;

public class TrapController : MonoBehaviour
{

    public GameObject cubeTrap;

    void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();

            for (int i=0; i<7; i++)
            {
                float randomX = UnityEngine.Random.Range(-20, 20);
                float randomZ = UnityEngine.Random.Range(-20, 20);

                var cube = (GameObject)Instantiate(cubeTrap,
                                                    new Vector3(randomX, 15, randomZ), 
                                                    Quaternion.identity);

                Destroy(cube, 5.0f);
            }
        }
    }

}
