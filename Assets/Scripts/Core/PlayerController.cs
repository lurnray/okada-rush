using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3.0f; // Distance between lanes
    private int currentLane = 1; // Middle lane

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
        targetPosition.x = (currentLane - 1) * laneDistance; // Adjust lane position
        transform.position = targetPosition;
    }
}
