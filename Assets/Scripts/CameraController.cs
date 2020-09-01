using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private float halfWidth;
    private float halfHeight;

    private GameObject player;
    private Vector3 playerPosition;
    private float moveSpeed = 2.0f;

    public BoxCollider2D bounds;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private static bool exists;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        player = GameObject.FindWithTag("Player");

        minBounds = bounds.bounds.min;
        maxBounds = bounds.bounds.max;

        mainCamera = GetComponent<Camera>();
        halfHeight = mainCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPosition, moveSpeed * Time.deltaTime);

        float clampX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
