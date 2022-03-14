using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class count : MonoBehaviour

{
    
    private GameManager gameManager;
    public int goalPoint;
    

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void OnTriggerEnter(Collider collider)
    {
       
        if (collider.CompareTag("Ball"))
        {
            gameManager.UpdateScore(goalPoint);
            
            Debug.Log("Score point");
        }
        
        Debug.Log("Was triggered");

    }
}


