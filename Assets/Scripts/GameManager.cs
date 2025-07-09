using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI ScoreText;
    public int Player1Score;
    public int Player2Score;
    public GameObject Ball;

    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = Player1Score + " | " + Player2Score;
        UpdatePlayer1Score(0);
        UpdatePlayer2Score(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayer2Score(int scoreToAdd)
    {
        Player2Score += scoreToAdd;
        ScoreText.text = Player1Score + " | " + Player2Score;
        if (Player2Score == 3)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            //Player2Win
            Destroy(Ball);
        }
    }

    public void UpdatePlayer1Score(int scoreToAdd)
    {
        Player1Score += scoreToAdd;
        ScoreText.text = Player1Score + " | " + Player2Score;
        if (Player1Score == 3)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            //Player1Win
            Destroy(Ball);
        }
    }
    
}
