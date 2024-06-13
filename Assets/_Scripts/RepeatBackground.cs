using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private float mitadFondo;
    private Vector3 posInicial;

    private void Start()
    {
        mitadFondo = GetComponent<BoxCollider>().size.x / 2;
        posInicial = transform.position;


    }

    private void Update()
    {
        if (posInicial.x - transform.position.x >= mitadFondo)
        {
            transform.position = posInicial;
        }
    }
}
