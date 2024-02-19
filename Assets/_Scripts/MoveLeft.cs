using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField, Range(-20, 20), Tooltip("Velocidad de movimiento en X")]
    private float speed = 8;

    private bool gameOver;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("Player").GetComponent<PlayerController>().GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        }
        
}
