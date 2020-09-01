using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    private float moveSpeed = 1.5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPosition, moveSpeed * Time.deltaTime);
    }
}
