using UnityEngine;

public class LineObstacleController : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float moveDistance = 3f;

    private Vector3 startPosition;
    private float direction = 1f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the obstacle
        transform.Translate(Vector3.right * moveSpeed * direction * Time.deltaTime);

        // If it goes too far in one direction, reverse
        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
        {
            direction *= -1f;
        }
    }
}
