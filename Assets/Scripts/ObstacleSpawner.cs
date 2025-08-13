using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject[] obstaclePrefabs;

    public float spawnDistance = 5f; // distance between spawns
    public float spawnAheadDistance = 10f; // how far above the camera to spawn
    public float[] xPositions = new float[] { 0f, -2.5f, 2.5f }; // possible x positions

    private float nextSpawnY;

    void Start()
    {
        nextSpawnY = cameraTransform.position.y + spawnAheadDistance;
    }

    void Update()
    {
        // move spawner above camera
        transform.position = new Vector3(
            cameraTransform.position.x,
            cameraTransform.position.y + spawnAheadDistance,
            0f
        );

        // check if we need to spawn
        if (transform.position.y >= nextSpawnY)
        {
            SpawnObstacle();
            nextSpawnY += spawnDistance;
        }
    }

    void SpawnObstacle()
    {
        // pick a random obstacle prefab
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // pick a random lane
        float x = xPositions[Random.Range(0, xPositions.Length)];

        // spawn at current spawner position
        Instantiate(prefab, new Vector3(x, transform.position.y, 0f), Quaternion.identity);
    }
}
