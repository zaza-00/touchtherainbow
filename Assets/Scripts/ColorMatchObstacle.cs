using UnityEngine;

public class ColorMatchObstacle : MonoBehaviour
{
    public Color obstacleColor = Color.red;
    private SpriteRenderer sr;
    private LineRenderer lr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lr = GetComponent<LineRenderer>();

        if (sr == null && lr == null)
            Debug.LogWarning("No compatible renderer found on " + gameObject.name);

        if (obstacleColor == Color.red)
        {
            if (sr != null) obstacleColor = sr.color;
            else if (lr != null) obstacleColor = lr.startColor;
        }

        if (sr != null) sr.color = obstacleColor;
        if (lr != null) { lr.startColor = obstacleColor; lr.endColor = obstacleColor; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BallColor playerBall = other.GetComponent<BallColor>();

            if (playerBall != null)
            {
                if (!ColorsMatch(playerBall.currentColor, obstacleColor))
                {
                    AudioManager.Instance.PlayGameOverSound();
                    Destroy(other.gameObject);
                }
                else
                {
                    playerBall.AddPoint();
                }
            }
        }
    }

    private bool ColorsMatch(Color a, Color b)
    {
        return Mathf.Approximately(a.r, b.r) &&
               Mathf.Approximately(a.g, b.g) &&
               Mathf.Approximately(a.b, b.b);
    }
}
