using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private float posWidght;
    private Vector3 startPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        posWidght = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if (startPos.x - transform.position.x > posWidght)
        {
            transform.position = startPos;
        }
    }
}

    // Update is called once per frame
   
