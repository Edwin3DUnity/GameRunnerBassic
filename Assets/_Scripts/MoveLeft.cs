using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField, Range(-20, 20), Tooltip("Velocidad de movimiento en X")]
    private float speed = 8;

    private PlayerController _player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.GameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        }
        
}
