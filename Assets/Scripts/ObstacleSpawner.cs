using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform cameraTransform;   
    public GameObject[] obstaclePrefabs; 
    public float spawnInterval = 5f;    
    public float spawnAheadDistance = 10f; 

    private float nextSpawnY;

    void Start()
    {
        nextSpawnY = cameraTransform.position.y + spawnAheadDistance;
    }

    void Update()
    {
        // Make the spawner follow the camera’s X & Y position
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + spawnAheadDistance, 0f);

        // Spawn new obstacles when the spawner moves up far enough
        if (transform.position.y >= nextSpawnY)
        {
            SpawnObstacle();
            nextSpawnY += spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        // Pick a random prefab
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Spawn at spawner's position
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
