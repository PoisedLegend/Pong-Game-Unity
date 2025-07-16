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
    public int randomNumber;
    public GameObject Player2PVP;
    public GameObject Player2PVE;
    public GameObject titleScreen;
    public bool isGameActive;

    public Button restartButton;
    // Start is called before the first frame update
    public void Start()
    {
        //Player2 = GetComponent<Controller2>();
        Time.timeScale = 0f;
        isGameActive = false;
        titleScreen.gameObject.SetActive(true);
        StartCoroutine(GenerateRandomNumbers());
    }
    
     IEnumerator GenerateRandomNumbers()
    {
        while (true)
        {
            randomNumber = Random.Range(0, 3);
            Debug.Log(randomNumber);
            yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        }
    }

    public void PVPStartGame()
    {
        Player2PVP.gameObject.SetActive(true);
        Time.timeScale = 1f;
        isGameActive = true;

        titleScreen.gameObject.SetActive(false);
        ScoreText.text = Player1Score + " | " + Player2Score;
        UpdatePlayer1Score(0);
        UpdatePlayer2Score(0);
    }

    public void PVEStartGame()
    {
        //Player2PVP.gameObject.SetActive(false);
        Player2PVE.gameObject.SetActive(true);
        Time.timeScale = 1f;
        isGameActive = true;
        
        titleScreen.gameObject.SetActive(false);
        ScoreText.text = Player1Score + " | " + Player2Score;
        UpdatePlayer1Score(0);
        UpdatePlayer2Score(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
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
