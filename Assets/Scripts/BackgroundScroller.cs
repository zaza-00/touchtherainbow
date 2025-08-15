using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Camera mainCamera;
    public float scrollSpeed = 0.1f;
    public Material bgMaterial;

    private Transform camTransform;
    private Vector3 startOffset;
    private Vector2 offset;

    void Start()
    {
        camTransform = mainCamera.transform;
        startOffset = transform.position - camTransform.position;
    }

    void LateUpdate()
    {
        // Make background follow camera
        transform.position = camTransform.position + startOffset;

        // Scroll texture
        offset.y = camTransform.position.y * scrollSpeed;
        bgMaterial.SetVector("_Offset", offset);
    }
}
