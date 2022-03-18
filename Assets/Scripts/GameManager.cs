using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

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
   
    //adding static to test
    public int score;

   // public static int highScore;

    public bool isGameActive;

    //For instance for keeping persistant data
    public static GameManager Instance { get; private set; }

    //For Inputting highscore
    public GameObject highScoreRecorder;

    public GameObject leaderBoard;
    public Button Confirm;

    public TMP_InputField yourUserNameInput;

    public TextMeshProUGUI userAndScoreObject;
    
    public string UserandScores;
    public string inputedUserName;
    
   
    //taken for scoringg?

    public static int scoreForBoard;
    private string basicScore;
    public TextMeshProUGUI basicScoreObject;
    public int highScore;
    public int newhighScore;
    public string highscorestring;
    public TextMeshProUGUI highScoreObject;


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

        //for scoring?
        highScore = PlayerPrefs.GetInt("highScore");
        PlayerPrefs.GetInt("highScore", newhighScore);
        highscorestring = "High Score: " + newhighScore.ToString();
        highScoreObject.text = (highscorestring);

        //for user name

        LoadScore();
        UserandScores = "User: " + inputedUserName + " High Score: " + highScore.ToString();
        userAndScoreObject.text = (UserandScores);

        
        Confirm.onClick.AddListener(ConfirmisClicked);

        
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
        scoreForBoard = score;
        basicScore = "Score: " + scoreForBoard.ToString();
        basicScoreObject.text = (basicScore);
        
        if (score > highScore)
        {
            newhighScore = scoreForBoard;
            PlayerPrefs.SetInt("highScore", newhighScore);
            highscorestring = "High Score: " + newhighScore.ToString();
            highScoreObject.text = (highscorestring);
            
        }
        else
        {
            PlayerPrefs.SetInt("highScore", highScore);
            highscorestring = "High Score: " + highScore.ToString();
            highScoreObject.text = (highscorestring);
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
        }
    }

    public void ConfirmisClicked()
    {


        //keep track of new users and scores
        if (score > highScore)
        {
            highScore = scoreForBoard;
            inputedUserName = yourUserNameInput.text;
            UserandScores = "User: " + inputedUserName + " High Score: " + highScore.ToString();
            userAndScoreObject.text = (UserandScores);
            SaveScore();
        Debug.Log("Confirm was clicked and data recorded");
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

    // Trying to keep a high score below 
    [System.Serializable]
    class SaveData
    {
        public int highScoreSave;
        public string userAndScoreData;
        public string inputedUserNameSave;
    }
    public void SaveScore()
    {
       
            SaveData data = new SaveData();
            data.highScoreSave = highScore;
        data.userAndScoreData = userAndScoreObject.text;
        data.inputedUserNameSave = inputedUserName;

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

            highScore = data.highScoreSave;
            userAndScoreObject.text = data.userAndScoreData;
            inputedUserName = data.inputedUserNameSave;
        }
    }

}