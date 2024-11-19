using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab de los enemigos
    public float spawnInterval = 2f;  // Intervalo de aparición de enemigos
    public int score = 0;  // Puntaje del juego


    private bool isGameOver = false;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);  // Comenzar a generar enemigos
    }

    void SpawnEnemy()
    {
        if (isGameOver) return;

        float randomX = Random.Range(-7.5f, 7.5f);  // Posición aleatoria en el eje X
        Vector2 spawnPosition = new Vector2(randomX, 6f);  // Parte superior de la pantalla

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);  // Crear enemigo
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        // Aquí podrías hacer algo para finalizar el juego (por ejemplo, mostrar una pantalla de Game Over)
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
