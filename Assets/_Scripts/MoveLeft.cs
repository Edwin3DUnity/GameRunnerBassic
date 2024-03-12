using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField, Range(0, 22), Tooltip("velocidad de movimiento")]
    private float speed = 6;

    private PlayerControlador _playerControlador;
    // Start is called before the first frame update
    void Start()
    {
        _playerControlador = GameObject.Find("Player").GetComponent<PlayerControlador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerControlador.GameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }
}
