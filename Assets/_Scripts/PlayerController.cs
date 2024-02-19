using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField, Range(1, 30), Tooltip("Fuerza de impulso hacia arriba para saltar")]
    private float jumpForce = 8;

    [SerializeField] private bool isOnGround; 
    
    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
     Jump();   
    }


    private void Jump()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround )
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
            gameOver = true;
            Debug.Log("Gamer Over");
            
        }
        
    }

    
    
    
}
