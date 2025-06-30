using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum GameState { Paused, Playing, GameOver }

    private GameState currentState;
    private int score;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        SetPaused();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentState == GameState.Paused)
            {
                Play();
            }
            else if (currentState == GameState.Playing)
            {
                GameOver();
            }
            else if (currentState == GameState.GameOver)
            {
                SetPaused(); // Reset to pause from GameOver
            }
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOverUI.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f;
        currentState = GameState.Playing;

        Pipes[] pipes = Object.FindObjectsByType<Pipes>(FindObjectsSortMode.None);
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void SetPaused()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
        currentState = GameState.Paused;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
        gameOverUI.SetActive(true);
        playButton.SetActive(true);
        currentState = GameState.GameOver;
        player.transform.position = Vector3.zero;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
