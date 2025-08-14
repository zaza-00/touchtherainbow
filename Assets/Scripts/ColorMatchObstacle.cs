using UnityEngine;

public class ColorMatchObstacle : MonoBehaviour
{
    public Color obstacleColor = Color.red; // Set in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BallColor playerBall = other.GetComponent<BallColor>();

            if (playerBall != null)
            {
                // Compare colors by checking their distance
                if (!ColorsMatch(playerBall.currentColor, obstacleColor))
                {
                    Debug.Log("Wrong color! Player loses!");
                    Destroy(other.gameObject); // Or trigger your game over
                }
            }
        }
    }

    private bool ColorsMatch(Color a, Color b)
    {
        // Allow a small tolerance in case of slight differences
        float tolerance = 0.01f;
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
    }
}
