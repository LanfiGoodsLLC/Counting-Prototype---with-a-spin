using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GoToHighScores : MonoBehaviour
{
    private GameManager gameManager;

    private Button highScoreMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        highScoreMenu = GetComponent<Button>();

        highScoreMenu.onClick.AddListener(HighScoreMenuButton);
    }

    void HighScoreMenuButton()
    {
        SceneManager.LoadScene(2);
        gameManager.titleScreen.SetActive(false);
        gameManager.scoreText.gameObject.SetActive(false);
        gameManager.timerText.gameObject.SetActive(false);

        gameManager.leaderBoard.gameObject.SetActive(true);
    }
}
