using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 15), Tooltip("Fuerza de salto")]
    private float jumpForce = 8;


    private Rigidbody _rigidbody;

    public bool isGrond;
    
    private const string SPEED_F ="Speed_f";
    private const string  JUMP_TRIG = "Jump_trig";
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";

    
    private Animator _animator;

    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }
    
    
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
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + Time.time /10);
        if (Input.GetKeyDown(KeyCode.Space) && isGrond)
        {
           
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrond = false;
            
            _animator.SetTrigger(JUMP_TRIG);
            
        }
        
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrond = true;
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

        }
    }
}
