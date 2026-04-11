using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private bool playerAlive = true;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (playerAlive && player != null && player.gameObject.activeSelf)
        {
            Vector3 rotatedOffset = player.rotation * offset;

            transform.position = player.position + rotatedOffset;
        }
    }

    public void OnPlayerDeath()
    {
        playerAlive = false;

        Camera cam = GetComponent<Camera>();
        if (cam != null)
        {
            cam.enabled = false;
        }
    }
}