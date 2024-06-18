using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround2 : MonoBehaviour
{
    private Vector3 posInicial;

    private float mitadFondo;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        mitadFondo = GetComponent<BoxCollider>().size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {

        if (posInicial.x - transform.position.x >= mitadFondo)
        {
            transform.position = posInicial;
        }
        
    }
}
