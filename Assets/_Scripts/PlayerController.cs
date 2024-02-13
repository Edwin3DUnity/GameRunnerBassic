
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(-2, 50), Tooltip("Fuerza que se le va aplicar al jugador para que salte")]
    private float jumpForce = 12;


    private Rigidbody playerRB;


    [SerializeField, Range(-10, 10), Tooltip("Factor multiplicador de gravedad")]
    private float gravityMultiplier;

    [SerializeField, Tooltip("Confirmar si está en el piso")]
    private bool isOnGround;
    
   
    void Start()
    {

        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;

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
