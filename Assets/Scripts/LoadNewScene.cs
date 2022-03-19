using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadNewScene : MonoBehaviour
{
    //INHERITANCE - Most of these scripts take from the Game Manager Class in some form.
    private GameManager gameManager;

    private Button highScoreMenu;

    private Button howToPlay;

    private Button returnToMenu;

    private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
    }

   public void HighScoreMenuButton()
    {
        SceneManager.LoadScene(2);
        gameManager.titleScreen.SetActive(false);
        gameManager.leaderBoard.gameObject.SetActive(true);
    }

   public void howToPlayMenu()
    {
        SceneManager.LoadScene(1);
        gameManager.titleScreen.SetActive(false);
    }

  public void ReloadMenu()
    {
        SceneManager.LoadScene(0);
        gameManager.titleScreen.SetActive(true);
        gameManager.leaderBoard.SetActive(false);
    }

  public void PlayButtonPressed()
    {
        gameManager.StartGame();
        gameManager.HealthTracker();
        Debug.Log(gameObject.name + " was clicked");
    }
}
