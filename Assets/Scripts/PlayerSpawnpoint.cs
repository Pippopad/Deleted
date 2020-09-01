using UnityEngine;

public class PlayerSpawnpoint : MonoBehaviour
{
    private PlayerController player;
    private CameraController mainCamera;

    public Vector2 direction;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        player.transform.position = transform.position;
        player.lastMove = direction;

        mainCamera = FindObjectOfType<CameraController>();
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
