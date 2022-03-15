using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

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

    public static int highScore;

    public bool isGameActive;

    //For instance for keeping persistant data
    public static GameManager Instance;

    //For leaderboard
    public string recordedScore;

    public GameObject highScoreRecorder;
    public TMP_InputField yourName;
    public TextMeshProUGUI yourScore;
    public Button Confirm;
    public Button notNow;


    public void Start()
    {
        //Making an instance
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //instance above

        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);


    }
    // Start is called before the first frame update
    public void StartGame()
    {
        isGameActive = true;

        
         
        if (isGameActive)
        {
            titleScreen.SetActive(false);
            scoreText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
            Debug.Log("titlescreen is off");
        }

        score = 0;
        timeLeft = 60;

        UpdateScore(0);
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
        isGameActive = false;
        if (!isGameActive)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            highScoreRecorder.gameObject.SetActive(true);

            yourScore.text = "Score: " + score;
        }


    
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        highScoreRecorder.gameObject.SetActive(false);

        titleScreen.SetActive(true);

    }
    public void UpdateScore(int scoreToAdd)
    {
        gameAudio.PlayOneShot(ballScore);
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    // Trying to keep a higgh score below 
    [System.Serializable]
    class SaveData
    {
        public int highScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
        }
    }

}
