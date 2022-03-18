using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    public Vector3 startPos;
    private float repeatWidth;
    private GameManager gameManager;
    public float speed;
    public Vector3 endingPos;

    // Start is called before the first frame update
    void Start()
    {
        
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
