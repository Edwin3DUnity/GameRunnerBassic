using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 25), Tooltip("Fuerza de salto")]
    private float jumpForce = 8;


    private Rigidbody _rigidbody;


    [SerializeField, Tooltip("Está en el suelo ")]
    private bool isGround;

    private Animator _animator;


    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLIER="SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
        _animator.SetFloat(SPEED_MULTIPLIER, 0.6f);
        
    }

    // Update is called once per frame
    void Update()
    {
      Jump();  
    }

    private void Jump()
    {
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + Time.deltaTime / 10);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            
            
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            _animator.SetTrigger(JUMP_TRIG);
            
            isGround = false;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
