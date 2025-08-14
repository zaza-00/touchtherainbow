using UnityEngine;

public class BallColor : MonoBehaviour
{
    public Color currentColor = Color.red; // Set in Inspector

    public void SetColor(Color newColor)
    {
        currentColor = newColor;
    }
}
