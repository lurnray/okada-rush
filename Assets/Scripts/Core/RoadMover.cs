using UnityEngine;

public class RoadMover : MonoBehaviour
{
    public float speed = 10f; // Speed at which the road moves
    public Transform resetPoint; // Point where the road resets

    void Update()
    {
        // Move the road backward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the road has passed the reset point
        if (transform.position.z <= resetPoint.position.z)
        {
            // Reset the road position
            ResetRoad();
        }
    }

    void ResetRoad()
    {
        // Adjust this to reset the road to its original position or spawn a new segment
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 100f);
    }
}
