
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
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= gravitymultiplier;

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
