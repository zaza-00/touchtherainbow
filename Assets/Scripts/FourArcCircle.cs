using UnityEngine;

[ExecuteAlways]
public class FourArcCircle : MonoBehaviour
{
    [Header("Circle Settings")]
    [Range(0.1f, 10f)]
    public float radius = 2f;
    [Range(0.01f, 1f)]
    public float lineThickness = 0.1f;
    [Range(4, 200)]
    public int segmentsPerArc = 10;

    [Header("Arc Colors")]
    public Color arc1Color = Color.red;
    public Color arc2Color = Color.green;
    public Color arc3Color = Color.blue;
    public Color arc4Color = Color.yellow;

    private LineRenderer[] arcRenderers = new LineRenderer[4];

    void OnEnable()
    {
        CreateArcRenderers();
        DrawArcs();
    }

    void OnValidate()
    {
        CreateArcRenderers();
        DrawArcs();
    }

    void CreateArcRenderers()
    {
        for (int i = 0; i < 4; i++)
        {
            if (arcRenderers[i] == null)
            {
                GameObject arcObj = new GameObject($"Arc_{i + 1}");
                arcObj.transform.SetParent(transform, false);
                LineRenderer lr = arcObj.AddComponent<LineRenderer>();

                lr.useWorldSpace = false;
                lr.loop = false;
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.widthMultiplier = lineThickness;
                lr.numCapVertices = 0; // rounded ends

                arcRenderers[i] = lr;
            }
        }
    }

    void DrawArcs()
    {
        Color[] colors = { arc1Color, arc2Color, arc3Color, arc4Color };
        float[] startAngles = { 0f, 90f, 180f, 270f };
        float[] endAngles = { 90f, 180f, 270f, 360f };

        for (int i = 0; i < 4; i++)
        {
            DrawArc(arcRenderers[i], startAngles[i], endAngles[i], colors[i]);
        }
    }

    void DrawArc(LineRenderer lr, float startAngle, float endAngle, Color color)
    {
        lr.startColor = color;
        lr.endColor = color;
        lr.widthMultiplier = lineThickness;

        int arcSegments = segmentsPerArc;
        lr.positionCount = arcSegments + 1;

        float angleStep = (endAngle - startAngle) / arcSegments;

        for (int i = 0; i <= arcSegments; i++)
        {
            float angle = Mathf.Deg2Rad * (startAngle + i * angleStep);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            lr.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
