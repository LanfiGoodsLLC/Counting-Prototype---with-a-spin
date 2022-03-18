using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ballLocation : MonoBehaviour
{
    private GameManager gameManager;
   
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Ball") && collision.gameObject.CompareTag("BoxWall"))
        {
            Destroy(gameObject);
            Debug.Log("Ball hit wall");
        }
        if(gameObject.CompareTag("Ball") && collision.gameObject.CompareTag("Ground"))
        {
            gameManager.ballHitGround += 1;
            Destroy(gameObject);
            gameManager.BallsPop();
            
            Debug.Log("Missed shot");
            
        }    
        if (gameManager.ballHitGround == 3)
        {
            gameManager.GameOver();
            Debug.Log("Ball dropped 3 times");
        }
        
    }
}