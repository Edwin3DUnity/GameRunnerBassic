using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("Velocidad de movimiento")]
    private float speedMove = 3;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        { 
            transform.Translate(Vector3.left * speedMove * Time.deltaTime);  
            
        }
         
    }
}
