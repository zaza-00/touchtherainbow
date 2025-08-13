using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject[] obstaclePrefabs;

    public float extraSpacing = 10f; 
    public float spawnAheadDistance = 10f;
    public float[] xPositions = new float[] { 0f, -2.5f, 2.5f };

    private float nextSpawnY;

    void Start()
    {
        nextSpawnY = cameraTransform.position.y + spawnAheadDistance;
    }

    void Update()
    {
        transform.position = new Vector3(
            cameraTransform.position.x,
            cameraTransform.position.y + spawnAheadDistance,
            0f
        );

        if (transform.position.y >= nextSpawnY)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        float x = xPositions[Random.Range(0, xPositions.Length)];

        GameObject obj = Instantiate(prefab, new Vector3(x, transform.position.y, 0f), Quaternion.identity);

        // Attach destroy script
        obj.AddComponent<DestroyBelowCamera>().cameraTransform = cameraTransform;

        float obstacleHeight = GetObjectHeight(obj);
        nextSpawnY = transform.position.y + obstacleHeight + extraSpacing;
    }


    float GetObjectHeight(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
            return 1f; // fallback height

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer rend in renderers)
        {
            bounds.Encapsulate(rend.bounds);
        }

        return bounds.size.y;
    }
}
