using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array of obstacle prefabs
    public float spawnInterval = 2f; // Time between spawns
    public float roadWidth = 6.0f; // Total width of the road
    public float spawnDistance = 50f; // Distance ahead of the player to spawn obstacles

    private Transform playerTransform;
    private float laneWidth;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        laneWidth = roadWidth / 3; // Divide road into 3 lanes
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0)
        {
            SpawnObstacle();
            spawnInterval = 2f; // Reset spawn interval
        }
    }

    void SpawnObstacle()
    {
        // Randomly select an obstacle prefab
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];

        // Randomly select a lane
        int lane = Random.Range(0, 3);
        float xPosition = (lane - 1) * laneWidth;

        // Calculate spawn position
        Vector3 spawnPosition = new Vector3(xPosition, 0.5f, playerTransform.position.z + spawnDistance);

        // Instantiate the obstacle
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }
}
