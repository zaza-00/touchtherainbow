using UnityEngine;

public class DestroyBelowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float offset = 5f; // How far below camera before destroying

    void Update()
    {
        if (transform.position.y < cameraTransform.position.y - offset)
        {
            Destroy(gameObject);
        }
    }
}
