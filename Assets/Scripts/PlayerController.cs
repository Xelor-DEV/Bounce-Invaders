using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float maxX = 7.5f;

    float movementHorizontal;

    void Update()
    {
        movementHorizontal = Input.GetAxisRaw("Horizontal"); // Detectar el input horizontal

        // Movimiento hacia la derecha
        if (movementHorizontal > 0 && transform.position.x < maxX)
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
        // Movimiento hacia la izquierda
        else if (movementHorizontal < 0 && transform.position.x > -maxX)
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}