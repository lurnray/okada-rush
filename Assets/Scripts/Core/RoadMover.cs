using UnityEngine;

public class RoadMover : MonoBehaviour
{
    public Transform resetPoint; // Assign in Inspector or programmatically
    public float speed = 10f;

    void Start()
    {
        // Programmatically find ResetPoint if not assigned
        if (resetPoint == null)
        {
            resetPoint = GameObject.Find("ResetPoint").transform;
            if (resetPoint == null)
            {
                Debug.LogError("ResetPoint not found in the scene! Ensure it exists.");
            }
        }
    }

    void Update()
    {
        if (resetPoint == null) return;

        // Move the road backward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the road is behind the reset point
        if (transform.position.z + 50f < resetPoint.position.z)
        {
            transform.position += Vector3.forward * 100f; // Adjust based on road length
        }
    }
}
