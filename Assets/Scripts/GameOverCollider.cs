using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.GameOver();  // Llamar al GameOver en el GameManager
        }
    }
}
