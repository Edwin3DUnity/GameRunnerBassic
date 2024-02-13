
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 50), Tooltip("Fuerza de salto ")]
    private float jumpForce = 8;

    private Rigidbody playerRB;

    [SerializeField] private bool isOnGround;
    
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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
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
        }
    }
}
