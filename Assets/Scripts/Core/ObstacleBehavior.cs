using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float tumbleForce = 5f; // Adjust the force for tumbling behavior

    private Rigidbody rb;

    void Start()
    {
        // Ensure the obstacle has a Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found! Please add one to " + gameObject.name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player hits the obstacle
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply a random force to make the obstacle tumble
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomDirection * tumbleForce, ForceMode.Impulse);

            // Optionally, add torque for a spinning effect
            Vector3 randomTorque = Random.insideUnitSphere * tumbleForce;
            rb.AddTorque(randomTorque, ForceMode.Impulse);
        }
    }
}
