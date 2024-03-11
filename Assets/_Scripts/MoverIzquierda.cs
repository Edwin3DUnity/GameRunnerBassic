using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverIzquierda : MonoBehaviour
{


    [SerializeField, Range(0, 20), Tooltip("velocidad de movimiento hacia la izquierda")]
    private float speed = 6;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    
}
