using UnityEngine;

public class DestroyBelowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float offset = 5f;

    void Update()
    {
        if (cameraTransform != null && transform.position.y < cameraTransform.position.y - offset)
        {
            Destroy(gameObject);
        }
    }
}
