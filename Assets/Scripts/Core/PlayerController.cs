using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3.0f; // Distance between lanes
    public float speed = 10.0f;       // Forward speed
    private int currentLane = 1;      // Middle lane
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Constant forward movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Handle lane switching
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLane(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveLane(1);
    }

    void MoveLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2); // Limit lanes to 0, 1, or 2
        Vector3 targetPosition = transform.position;
        targetPosition.x = (currentLane - 1) * laneDistance; // Calculate lane position
        transform.position = targetPosition;
    }
}
