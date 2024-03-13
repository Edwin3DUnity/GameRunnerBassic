using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField, Range(0, 20), Tooltip("Velocidad de movimiento")]
    private float speed = 7;

    private ControladorPlayer _controladorPlayer;

  
    
    // Start is called before the first frame update
    void Start()
    {
        _controladorPlayer = GameObject.Find("Player").GetComponent<ControladorPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (!_controladorPlayer.GameOver)
        {
            transform.Translate(Vector3.left * speed  * Time.deltaTime);    
        }
        
    }
}
