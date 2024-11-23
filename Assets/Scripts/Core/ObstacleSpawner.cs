using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array of obstacle prefabs
    public float spawnInterval = 2f; // Time between spawns
    public float roadWidth = 6.0f; // Total width of the road
    public float spawnDistance = 50f; // Distance ahead of the player to spawn obstacles

    private GameObject[] roadSegments; // Reference to road segments from RoadManager
    private Transform playerTransform;
    private float laneWidth;
    private float timer = 0;

    void Start()
    {
        // Get the player reference
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate lane width
        laneWidth = roadWidth / 3;

        // Access road segments from RoadManager
        RoadManager roadManager = FindObjectOfType<RoadManager>();
        if (roadManager != null)
        {
            roadSegments = roadManager.GetRoadSegments(); // Access road segments
        }
        else
        {
            Debug.LogError("RoadManager not found! Ensure it exists in the scene.");
        }
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

        // Randomly select a lane
        int lane = Random.Range(0, 3);
        float xPosition = (lane - 1) * laneWidth;

        // Calculate spawn position
        Vector3 spawnPosition = new Vector3(xPosition, 0.5f, playerTransform.position.z + spawnDistance);

        // Assign the obstacle to the nearest road segment
        GameObject nearestRoad = FindNearestRoad(spawnPosition);
        if (nearestRoad != null)
        {
            obstacle.transform.SetParent(nearestRoad.transform);
        }

        // Set the obstacle's position
        obstacle.transform.position = spawnPosition;
    }

    GameObject FindNearestRoad(Vector3 position)
    {
        if (roadSegments == null || roadSegments.Length == 0)
        {
            Debug.LogError("Road segments not assigned! Ensure the RoadManager is functioning properly.");
            return null;
        }

        GameObject nearestRoad = null;
        float minDistance = float.MaxValue;
        foreach (GameObject road in roadSegments)
        {
            float distance = Vector3.Distance(position, road.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestRoad = road;
            }
        }
        return nearestRoad;
    }
}
