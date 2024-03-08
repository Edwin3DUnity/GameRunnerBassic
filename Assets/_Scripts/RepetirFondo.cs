using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour
{

    private float mitadFondo;

    private Vector3 posInicial;
    
    
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;

        mitadFondo = GetComponent<BoxCollider>().size.x / 2;


    }

    // Update is called once per frame
    void Update()
    {
        if (posInicial.x - transform.position.x > mitadFondo)
        {
            transform.position = posInicial;
        }
        
    }
}
