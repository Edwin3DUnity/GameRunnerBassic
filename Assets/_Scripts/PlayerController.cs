using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField, Range(0, 18), Tooltip("Fuerca de salto ")]
    private float jumpForce = 8;

    private Rigidbody _rigidbody;

    public bool isGround;

    private Animator _animator;
    

    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG =  "Jump_trig";
    private const string SPEEDMULTIPLIER =  "SpeedMultiplier";


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
        _animator.SetFloat(SPEEDMULTIPLIER, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        
        _animator.SetFloat(SPEEDMULTIPLIER , 1  + Time.time /10);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround )
        {
            
            _rigidbody.AddForce(Vector3.up *  jumpForce , ForceMode.Impulse);
            isGround = false;
            _animator.SetTrigger(JUMP_TRIG);

        }
        
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            _animator.SetFloat(SPEED_F, 0);
            
        }
    }
}
