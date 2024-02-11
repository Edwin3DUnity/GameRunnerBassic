using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{


    private Rigidbody playerRB;

    [SerializeField, Range(-2, 20), Tooltip(" Fueza de salto")]
    private float jumpForce = 8;

    [SerializeField, Range(-10, 10), Tooltip("multimplador de gravedad")]
    private float gravityMultiplier;

    [SerializeField] private bool isOnGround;
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
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
