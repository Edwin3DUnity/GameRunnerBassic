using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip(" Fuerza aplicada para el salto")]
    private float jumpForce = 8;


    private Rigidbody playerRB;

    [SerializeField, Tooltip(" Está tocando el suelo")]
    private bool IsOnground;

    [SerializeField, Range(-10, 10)] private float gravityMultiplier;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnground)
        {
            playerRB.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);

            IsOnground = false;
        }  
        
    }

    private void OnCollisionEnter(Collision other)
    {
        IsOnground = true;
    }
}
