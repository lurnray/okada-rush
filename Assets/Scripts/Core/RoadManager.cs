using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab; // Prefab for a single road slice
    public int numRoadSegments = 5; // Number of road segments to loop
    public float roadLength = 50f; // Length of one road slice

    private GameObject[] roadSegments;

    void Start()
    {
        roadSegments = new GameObject[numRoadSegments];

        // Initialize road segments end-to-end
        for (int i = 0; i < numRoadSegments; i++)
        {
            roadSegments[i] = Instantiate(roadPrefab, new Vector3(0, 0, i * roadLength), Quaternion.identity);
        }
    }

    void Update()
    {
        foreach (GameObject road in roadSegments)
        {
            if (road.transform.position.z + roadLength < Camera.main.transform.position.z)
            {
                // Move the road segment to the end of the farthest road
                float newZPosition = GetFarthestRoadPosition() + roadLength;
                road.transform.position = new Vector3(0, 0, newZPosition);
            }
        }
    }

    float GetFarthestRoadPosition()
    {
        float farthestZ = float.MinValue;
        foreach (GameObject road in roadSegments)
        {
            if (road.transform.position.z > farthestZ)
            {
                farthestZ = road.transform.position.z;
            }
        }
        return farthestZ;
    }
}
