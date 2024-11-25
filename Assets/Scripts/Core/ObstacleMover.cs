using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move the obstacle backward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Destroy the obstacle if it moves too far behind the player
        if (transform.position.z < Camera.main.transform.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }
}
