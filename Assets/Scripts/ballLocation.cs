using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballLocation : MonoBehaviour
{
    private GameManager gameManager;
    public AudioClip lose;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Ball") && collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
            Debug.Log("Missed shot");
            
        }    
    }
}