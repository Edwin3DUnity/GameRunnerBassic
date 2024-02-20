using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("Fuerza hacia arriba para saltar")]
    private float jumpForce = 8;


    private Rigidbody _rigidbody;

    [SerializeField, Range(-10, 10), Tooltip("Factor de multiplicador de gravedad")]
    private float gravityMultiplier = 1;

    [SerializeField] private bool isOnGround;

    private bool gameOver;


    private Animator _animator;
    const string SPEED_MULTIPLIER = "Speed Multiplier";
    const string JUMP_TRIG = "Jump_trig";
    private const string SPEED_F = "Speed_f";

    public bool GameOver
    {
        get => gameOver;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

       Physics.gravity *= gravityMultiplier;
       _animator = GetComponent<Animator>();
       _animator.SetFloat(SPEED_F , 1);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    private void Jump()
    {
        
        _animator.SetFloat( SPEED_MULTIPLIER,  1 + Time.time/ 10);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false )
        {
            _rigidbody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isOnGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
        }
        
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            gameOver = true;
        }
    }
    
    
    
}
