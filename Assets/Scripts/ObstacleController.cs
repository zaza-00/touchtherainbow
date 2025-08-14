using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float rotationSpeed = 70f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
