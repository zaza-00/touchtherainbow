using UnityEngine;
using TMPro;

public class BallColor : MonoBehaviour
{
    public Color currentColor = Color.red;
    private SpriteRenderer sr;
    private LineRenderer lr;

    public TMP_Text pointsText;
    private int points = 0;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        lr = GetComponent<LineRenderer>();

        if (sr == null && lr == null)
            Debug.LogWarning("No compatible renderer found on " + gameObject.name);

        if (currentColor == Color.red)
        {
            if (sr != null) currentColor = sr.color;
            else if (lr != null) currentColor = lr.startColor;
        }

        ApplyColor();
        UpdatePointsUI();
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
            visibleColor.a = 1f;
            sr.color = visibleColor;
        }

        if (lr != null)
        {
            lr.startColor = currentColor;
            lr.endColor = currentColor;
        }
    }

    public void AddPoint()
    {
        points++;
        UpdatePointsUI();
        AudioManager.Instance.PlayPointSound();
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
            pointsText.text = "Points: " + points;
    }

    public void PlayGameOverSound()
    {
        AudioManager.Instance.PlayGameOverSound();
    }

    public void PlayStartTune()
    {
        AudioManager.Instance.PlayStartTune();
    }
}
