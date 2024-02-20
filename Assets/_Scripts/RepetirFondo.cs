using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour
{

    private float mitadFondo;

    private Vector3 startPos;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        mitadFondo = GetComponent<BoxCollider>().size.x / 2;

        startPos = transform.position;
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (startPos.x - transform.position.x >= mitadFondo)
        {
            transform.position = startPos;
        }
        
    }
}
