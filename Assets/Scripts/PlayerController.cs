using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Text txtScore;
    public Text txtVictory;
    public GameObject btnAgain;
    private int scoreboard = 0;
    public CameraController cameraController;
    public GameObject pauseMenu;
    private bool isPaused = false;
    public AudioSource shoot;
    public AudioSource death;

    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();

        shoot = sources[0];
        death = sources[1];

        txtVictory.gameObject.SetActive(false);
        btnAgain.SetActive(false);
    }

    void Update()
    {
        if (isPaused) return;
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

        if (shoot != null) shoot.Play();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bullet.transform.forward * 6f;

        BulletController bc = bullet.GetComponent<BulletController>();
        if (bc != null)
        {
            bc.player = this;
        }

        Destroy(bullet, 3f);
    }

    public void AddScore()
    {
        scoreboard++;
        txtScore.text = "Scoreboard: " + scoreboard;

        if (scoreboard >= 7)
        {
            txtVictory.gameObject.SetActive(true);
            btnAgain.SetActive(true);
            txtScore.gameObject.SetActive(false);
        }
    }

    public void AgainScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Die()
    {
       if (death != null && death.clip != null)
        {
        death.Play();
        }
        
        scoreboard = 0;
        txtScore.text = "Scoreboard: 0";
        
        gameObject.SetActive(false);

        if (cameraController != null)
        {
            cameraController.OnPlayerDeath();
        }

        btnAgain.SetActive(true);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
        //RESUME
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        }
        else
        {
        //PAUSE
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        }
    }
    public void BackToMenu()
    {
    Time.timeScale = 1.0f;
    SceneManager.LoadScene("MainMenu");
    }
}