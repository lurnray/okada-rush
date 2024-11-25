using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject road; // Reference to the road GameObject
    public float speed = 10f; // Forward speed of the okada
    private float laneWidth; // Width of each lane
    private int currentLane = 1; // Middle lane (0 = left, 1 = center, 2 = right)

    void Start()
    {
        // Calculate lane width based on the road's width
        float roadWidth = road.transform.localScale.x;
        laneWidth = roadWidth / 3; // Divide road into 3 lanes
    }

    void Update()
    {
        // Handle lane switching
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(1);
        }
    }

    void MoveLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2); // Restrict to 3 lanes
        float xPosition = (currentLane - 1) * laneWidth; // Calculate X position for the lane
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
