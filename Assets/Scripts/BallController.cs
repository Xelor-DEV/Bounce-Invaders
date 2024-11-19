using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public float speed  = 10;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = Vector3.down * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  // Destruir enemigo
            gameManager.IncrementScore();  // Aumentar puntaje
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);  // Destruir la bola
    }
}
