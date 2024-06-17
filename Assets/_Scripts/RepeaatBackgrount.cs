using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaatBackgrount : MonoBehaviour
{

    private Vector3 posinicial;

    private float mitadFondo;

    private PlayerCOntrooller _playerCOntrooller;
    
    // Start is called before the first frame update
    void Start()
    {
        posinicial = transform.position;

        mitadFondo = GetComponent<BoxCollider>().size.x / 2;


    }

    // Update is called once per frame
    void Update()
    {
        if(posinicial.x - transform.position.x >= mitadFondo)
        {
            transform.position = posinicial;
        }
    }
}
