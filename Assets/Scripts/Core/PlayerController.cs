using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject road; // Reference to the road GameObject
    private float laneWidth;

    private int currentLane = 1; // Middle lane

    void Start()
    {
        // Calculate lane width based on the road's scale
        laneWidth = road.transform.localScale.x / 3;
    }

    void Update()
    {
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
        targetPosition.x = (currentLane - 1) * laneWidth; // Recalculate X position based on lane
        transform.position = targetPosition;
    }
}
