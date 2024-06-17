using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft1 : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("Velocidad de movimiento")]
    private float speedMove = 8;

    private PlayerCOntrooller _playerCOntrooller;
    // Start is called before the first frame update

    
    void Start()
    {
        _playerCOntrooller = GameObject.Find("Player").GetComponent<PlayerCOntrooller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerCOntrooller.GameOver)
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime);      
        }
      
    }
}
