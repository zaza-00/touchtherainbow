using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float jumpForce = 0.5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        
        if (vertical > 0f)
        {
            HandleJump(horizontal);
        }
    }

    void HandleJump(float horizontalInput)
    {
        float xVelocity = 0f;

        if (horizontalInput < 0f)
        {
            
            xVelocity = -moveSpeed * 0.5f;
        }
        else if (horizontalInput > 0f)
        {
            
            xVelocity = moveSpeed * 0.5f;
        }

        
        rb.linearVelocity = new Vector2(xVelocity, jumpForce);
    }
}
