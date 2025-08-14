using UnityEngine;

public class BallColor : MonoBehaviour
{
    public Color currentColor = Color.red; // Logical color
    private SpriteRenderer sr;
    private LineRenderer lr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        lr = GetComponent<LineRenderer>();

        if (sr == null && lr == null)
        {
            Debug.LogWarning("No compatible renderer found on " + gameObject.name);
        }

        // Automatically pick up color from prefab if currentColor is default red
        if (currentColor == Color.red)
        {
            if (sr != null)
            {
                currentColor = sr.color;
            }
            else if (lr != null)
            {
                currentColor = lr.startColor;
            }
        }

        ApplyColor();
    }

    public void SetColor(Color newColor)
    {
        currentColor = newColor;
        ApplyColor();
    }

    private void ApplyColor()
    {
        if (sr != null)
        {
            Color visibleColor = currentColor;
            visibleColor.a = 1f; // Ensure fully visible
            sr.color = visibleColor;
        }

        if (lr != null)
        {
            lr.startColor = currentColor;
            lr.endColor = currentColor;
        }
    }
}
