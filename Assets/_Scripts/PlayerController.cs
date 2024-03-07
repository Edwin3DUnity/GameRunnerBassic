using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 15), Tooltip("Fuerza de salto")]
    private float jumpForce = 8;


    private Rigidbody _rigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
    }



    private void Jump()
    {
        
        
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }
    
    
}
