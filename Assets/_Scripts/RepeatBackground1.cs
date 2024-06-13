using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground1 : MonoBehaviour
{

    private float mitadfondo;
    private Vector3 posInicial;
    
    // Start is called before the first frame update
    void Start()
    {
        mitadfondo = GetComponent<BoxCollider>().size.x / 2;
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (posInicial.x - transform.position.x > mitadfondo)
        {
            transform.position = posInicial;
        }  
    }
}
