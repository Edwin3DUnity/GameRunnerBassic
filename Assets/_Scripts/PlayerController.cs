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

    private Animator _animator;

    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
    }

    // Update is called once per frame
    void Update()
    {
     Jump();   
    }


    private void Jump()
    {
        
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + Time.time / 10);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver )
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
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
