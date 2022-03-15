using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCanvas : MonoBehaviour
{
    public static KeepCanvas Instance;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

       

        //Making an instance
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //instance above
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
