using UnityEngine;

public class SegmentColor : MonoBehaviour
{
    public Color pieceColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerColor playerColor = collision.GetComponent<PlayerColor>();
            if (playerColor != null)
            {
                if (playerColor.currentColor != pieceColor)
                {
                    Debug.Log("Game Over!");
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
