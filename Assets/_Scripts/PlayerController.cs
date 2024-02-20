
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("fuerza de salto por impulso")]
    private float jumpForce;

    [SerializeField, Tooltip("Está tocando el suelo")]
    private bool isOnGround;

    private Rigidbody playerRB;

    [SerializeField, Range(-10, 20), Tooltip("Factor multiplicador de gravedad")]
    private float gravitymultiplier;

   private  bool _gameOver;

    public bool GameOver
    {
        get => _gameOver;

       
    }

    private Animator _animator;

    private const string SPEED_F = "Speed_f";
    private float speedF = 1;

    private const string MULTIPLIER_SPEED = "Multiplier_Speed";
    
    private const string JUMP_TRIG = "Jump_trig";
    
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= gravitymultiplier;

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
        
        _animator.SetFloat(MULTIPLIER_SPEED, 1 + Time.time /10);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
            _gameOver = true;
            Debug.Log("Game Over !!!");
            isOnGround = false;
        }
        
    }
}
