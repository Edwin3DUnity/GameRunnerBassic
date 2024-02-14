
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("Fuerza de salto de impulso")]
    private float jumpForce= 8;

    [SerializeField, Tooltip("Está en el suelo")]
    private bool isOnGround;

    private Rigidbody playerRB;

    private bool _gameOver;

    public bool gameOver
    {
        get => _gameOver;

        set
        {
            if (_gameOver == true)
            {
                _gameOver = true;
            }
            else
            {
                _gameOver = value;
            }
            
        }
    }
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
 
        Jump();
    }


    private void Jump()
    {
      
        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            isOnGround = false;
            Debug.Log("Game Over!!");
        }
        
    }
}
