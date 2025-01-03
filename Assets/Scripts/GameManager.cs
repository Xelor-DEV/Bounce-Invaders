using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab de los enemigos
    public float spawnInterval = 2f;  // Intervalo de aparicion de enemigos
    public int score = 0;  // Puntaje del juego
    public GameObject gameOverPanel;
    public TMP_Text scoreTxt;
    public TMP_Text pointsInScreen;
    public DBScoreSender dbScoreSender;  // Referencia al DBScoreSender

    public UserSessionData userSessionData;

    private bool isGameOver = false;

    public void ReceiveUserId(string userID)
    {
        userSessionData.userId = int.Parse(userID);
        Debug.Log("user id: " + userID);
    }

    void Start()
    {
        pointsInScreen.text = "Score: " + score;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);  // Comenzar a generar enemigos
    }

    void SpawnEnemy()
    {
        if (isGameOver) return;

        float randomX = Random.Range(-7.5f, 7.5f);  // Posicion aleatoria en el eje X
        Vector2 spawnPosition = new Vector2(randomX, 6f);  // Parte superior de la pantalla
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);  // Crear enemigo
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        scoreTxt.text = "Score: " + score;
        gameOverPanel.SetActive(true);

        // Enviar el puntaje a la base de datos
        dbScoreSender.SendScoreToDatabase(score, userSessionData.userId);
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("Score: " + score);
        pointsInScreen.text = "Score: " + score;
    }

    public void RestartGame()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}