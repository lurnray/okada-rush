using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab; // Prefab of a single road slice
    public int numRoadSegments = 5; // Number of road segments to loop
    public float roadLength = 50f; // Length of a single road segment
    private GameObject[] roadSegments;

    void Start()
    {
        // Initialize the road segments
        roadSegments = new GameObject[numRoadSegments];
        for (int i = 0; i < numRoadSegments; i++)
        {
            // Position each road segment end-to-end
            roadSegments[i] = Instantiate(roadPrefab, new Vector3(0, 0, i * roadLength), Quaternion.identity);
        }
    }

    void Update()
    {
        // Loop through all road segments and reposition them if they move behind the player
        foreach (GameObject road in roadSegments)
        {
            if (road.transform.position.z + roadLength < Camera.main.transform.position.z)
            {
                // Move the road segment to the end of the chain
                float newZPosition = GetFarthestRoadPosition() + roadLength;
                road.transform.position = new Vector3(0, 0, newZPosition);
            }
        }
    }

    public GameObject[] GetRoadSegments()
{
    return roadSegments;
}


    float GetFarthestRoadPosition()
    {
        // Find the farthest road segment's Z position
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
