using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float timeLeft;
    public AudioClip ballFalls;
    public AudioClip ballScore;
    public AudioClip timeEnd;
    public AudioSource gameAudio;
   
    public int score;

    public bool isGameActive;

    public static GameManager Instance;

    // Start is called before the first frame update
    public void StartGame()
    {
        timeLeft = 60;
        isGameActive = true;
        score = 0;
       


        titleScreen.SetActive(false);

        UpdateScore(0);
    }

    //Make Gamemanager active between both scenes
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

        // Update is called once per frame
        void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.SetText("Time: " + Mathf.Round(timeLeft));
            if (timeLeft < 0)
            {
                gameAudio.PlayOneShot(timeEnd);
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        gameAudio.PlayOneShot(ballFalls);
        
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateScore(int scoreToAdd)
    {
        gameAudio.PlayOneShot(ballScore);
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

}
