using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab; // Prefab of a single road slice
    public int numRoadSegments = 5; // Number of road segments to loop
    public float roadLength = 50f; // Length of a single road segment
    private GameObject[] roadSegments;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Create road segments
        roadSegments = new GameObject[numRoadSegments];
        for (int i = 0; i < numRoadSegments; i++)
        {
            roadSegments[i] = Instantiate(roadPrefab, new Vector3(0, 0, i * roadLength), Quaternion.identity);
        }
    }

    void Update()
    {
        // Check if any road segment is behind the player and reposition it
        foreach (GameObject road in roadSegments)
        {
            if (road.transform.position.z + roadLength < playerTransform.position.z)
            {
                road.transform.position += Vector3.forward * roadLength * numRoadSegments;
            }
        }
    }
}
