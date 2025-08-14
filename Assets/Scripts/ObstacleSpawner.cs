using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject[] obstaclePrefabs;

    public float extraSpacing = 10f;
    public float spawnAheadDistance = 10f;

    // Added corner positions — adjust X values for your scene
    public float[] xPositions = new float[] { 0f, -2.5f, 2.5f, -4f, 4f };

    private float nextSpawnY;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

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

        // If you want top-corner obstacles slightly higher, tweak Y position here
        float spawnY = transform.position.y;

        GameObject obj = Instantiate(prefab, new Vector3(x, spawnY, 0f), Quaternion.identity);

        DestroyBelowCamera destroyScript = obj.AddComponent<DestroyBelowCamera>();
        destroyScript.cameraTransform = cameraTransform;
        destroyScript.offset = 5f;

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
