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
    public int segmentsPerArc = 25;

    [Header("Arc Colors (Hex)")]
    public string arc1Hex = "#00BBEA";
    public string arc2Hex = "#FF0084";
    public string arc3Hex = "#8700FF";
    public string arc4Hex = "#00FF9C";

    private LineRenderer[] arcRenderers = new LineRenderer[4];
    private Color[] parsedColors = new Color[4];

    void Start()
    {
        ParseHexColors();
        CreateArcRenderers();
        DrawArcs();
    }

    void OnValidate()
    {
        ParseHexColors();
        CreateArcRenderers();
        DrawArcs();
    }

    void ParseHexColors()
    {
        string[] hexStrings = { arc1Hex, arc2Hex, arc3Hex, arc4Hex };
        for (int i = 0; i < hexStrings.Length; i++)
        {
            if (!ColorUtility.TryParseHtmlString(hexStrings[i], out parsedColors[i]))
            {
                Debug.LogWarning($"Invalid hex color at Arc {i + 1}: {hexStrings[i]}. Using white.");
                parsedColors[i] = Color.white;
            }
        }
    }

    void CreateArcRenderers()
    {
        for (int i = 0; i < 4; i++)
        {
            if (arcRenderers[i] == null)
            {
                // Check if child already exists to prevent duplicates
                Transform existingArc = transform.Find($"Arc_{i + 1}");
                if (existingArc != null)
                {
                    arcRenderers[i] = existingArc.GetComponent<LineRenderer>();
                    if (arcRenderers[i] != null)
                        continue;
                }

                GameObject arcObj = new GameObject($"Arc_{i + 1}");
                arcObj.transform.SetParent(transform, false);
                LineRenderer lr = arcObj.AddComponent<LineRenderer>();

                lr.useWorldSpace = false;
                lr.loop = false;
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.widthMultiplier = lineThickness;
                lr.numCapVertices = 5; // rounded ends

                arcRenderers[i] = lr;
            }
        }
    }

    void DrawArcs()
    {
        float[] startAngles = { 0f, 90f, 180f, 270f };
        float[] endAngles = { 90f, 180f, 270f, 360f };

        for (int i = 0; i < 4; i++)
        {
            DrawArc(arcRenderers[i], startAngles[i], endAngles[i], parsedColors[i]);
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
