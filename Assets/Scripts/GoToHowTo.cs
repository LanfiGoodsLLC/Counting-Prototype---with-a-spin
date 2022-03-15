using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GoToHowTo : MonoBehaviour
{
    private Button howToPlay;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        howToPlay = GetComponent<Button>();

        howToPlay.onClick.AddListener(howToPlayMenu);
    }

    void howToPlayMenu()
    {
        SceneManager.LoadScene(1);
        gameManager.titleScreen.SetActive(false);
    }

  
}
