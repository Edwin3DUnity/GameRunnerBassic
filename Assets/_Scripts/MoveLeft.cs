using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("velocidad de movimiento en el eje X")]
    private float speed = 8;

    private PlayerController _playerController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!_playerController.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);    
        }
        
    }
}
