using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnInterval = 1.5f;
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
        int lane = Random.Range(0, 3); // Choose a lane
        float xPosition = (lane - 1) * 3.0f; // Match lane distance
        Vector3 spawnPosition = new Vector3(xPosition, 0, transform.position.z + 20); // Spawn ahead
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPosition, Quaternion.identity);
    }
}
