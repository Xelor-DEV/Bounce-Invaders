using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;  // Velocidad de los enemigos
    private Rigidbody2D rb;   // Referencia al Rigidbody2D del enemigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtener el Rigidbody2D del enemigo
    }

    void FixedUpdate()
    {
        // Mover el enemigo hacia abajo usando física (usando Rigidbody2D)
        rb.velocity = new Vector2(0, -speed);  // Movimiento hacia abajo en el eje Y
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el enemigo colisiona con el GameOverCollider
        if (other.CompareTag("GameOver"))
        {
            Destroy(gameObject);  // Destruir el enemigo
        }

        // Si el enemigo colisiona con la bola
        if (other.CompareTag("Ball"))
        {
            Destroy(gameObject);  // Destruir el enemigo
        }
    }
}
