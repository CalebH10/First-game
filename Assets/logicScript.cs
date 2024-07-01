using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    public AudioSource pingSFX;
    public int highScore;
    [SerializeField] TextMeshProUGUI HighScoreText;

    public void Start()
    {
        UpdateHighScore();
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        pingSFX.Play();
        CheckHighScore();
    }


    public void CheckHighScore()
    {
        if(playerScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", playerScore);
            UpdateHighScore();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void UpdateHighScore()
    {
        HighScoreText.text = $"High Score: {PlayerPrefs.GetInt("Highscore", 0)}";
    }
}