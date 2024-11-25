using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array of obstacle prefabs
    public GameObject road; // Reference to the road GameObject
    public float spawnInterval = 2f; // Time between spawns
    public float spawnDistance = 50f; // Distance ahead of the player to spawn obstacles

    private float laneWidth;
    private float timer;

    void Start()
    {
        // Calculate lane width dynamically based on the road's width
        float roadWidth = road.transform.localScale.x;
        laneWidth = roadWidth / 3;
    }

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
        GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);

        // Randomly select a lane (0 = left, 1 = center, 2 = right)
        int lane = Random.Range(0, 3);
        float xPosition = (lane - 1) * laneWidth;

        // Calculate spawn position
        Vector3 spawnPosition = new Vector3(xPosition, 0.5f, Camera.main.transform.position.z + spawnDistance);

        // Set the obstacle's position
        obstacle.transform.position = spawnPosition;

        // Add movement to the obstacle (optional)
        ObstacleMover mover = obstacle.GetComponent<ObstacleMover>();
        if (mover == null)
        {
            mover = obstacle.AddComponent<ObstacleMover>();
        }
        mover.speed = 10f; // Match road speed
    }
}
