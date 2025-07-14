using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 2.0f;
    public float highestY;

    
    void Start()
    {
        if (target != null)
        {
            highestY = target.position.y;
        }
    }

   
    void LateUpdate()
    {
        if (target == null) return;
        if (target.position.y > highestY)
        {
            highestY = target.position.y;
        }
        Vector3 newPos = new Vector3(transform.position.x, highestY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
