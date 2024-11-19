using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array to hold potholes, roadblocks, etc.
    public float spawnInterval = 1.5f; // Time between spawns
    public float spawnDistance = 20f; // Distance ahead of the player to spawn obstacles
    public Transform player; // Reference to the player

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        // Randomly select an obstacle prefab
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];

        // Randomly select a lane (3 lanes: left, center, right)
        int lane = Random.Range(0, 3);
        float xPosition = (lane - 1) * 3.0f; // Adjust lane width (3 units apart)

        // Calculate spawn position
        Vector3 spawnPosition = new Vector3(xPosition, 0, player.position.z + spawnDistance);

        // Instantiate the obstacle
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }
}
