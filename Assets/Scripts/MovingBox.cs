using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private GameManager gameManager;
    public float speed;
    private Vector3 endingPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3 (-39f, 0.15f, -22.0f);
        endingPos = new Vector3 (-39f, 0.15f, 22f);
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = endingPos;
        }
        
    }
}
