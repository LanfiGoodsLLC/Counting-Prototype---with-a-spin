using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button playButton;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playButton = GetComponent<Button>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {
        gameManager.StartGame();
        Debug.Log(gameObject.name + " was clicked");
    }
}
