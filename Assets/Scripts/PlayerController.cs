using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float jumpForce = 0.5f;
    private Rigidbody2D rb;

    public TMP_Text startText;
    private bool gameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        if (startText != null)
            startText.gameObject.SetActive(true);
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (!gameStarted && vertical > 0f)
        {
            StartGame();
        }

        if (gameStarted && vertical > 0f)
        {
            HandleJump(horizontal);
        }
    }

    void StartGame()
    {
        gameStarted = true;
        rb.simulated = true;

        if (startText != null)
            startText.gameObject.SetActive(false);

        AudioManager.Instance.PlayStartTune();
    }

    void HandleJump(float horizontalInput)
    {
        float xVelocity = 0f;

        if (horizontalInput < 0f)
            xVelocity = -moveSpeed * 0.5f;
        else if (horizontalInput > 0f)
            xVelocity = moveSpeed * 0.5f;

        rb.linearVelocity = new Vector2(xVelocity, jumpForce);
    }
}
