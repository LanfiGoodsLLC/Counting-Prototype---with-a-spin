using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour
{
    private Button returnMenu;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        returnMenu = GetComponent<Button>();

        returnMenu.onClick.AddListener(ReloadMenu);
    }

    void ReloadMenu()
    {
        SceneManager.LoadScene(0);
        gameManager.titleScreen.SetActive(true);
        gameManager.leaderBoard.SetActive(false);
    }
}
