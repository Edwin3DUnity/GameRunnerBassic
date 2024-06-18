using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField, Range(0, 20), Tooltip(" velocidad de movimiento")]
    private float speedMove = 8;

    [SerializeField, Range(0, 360), Tooltip(" velocidad de Rotacion del barril")]
    private float gradeRotation = 360;

    private PlayerControllerr _playerControllerr;
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerr = GameObject.Find("Player").GetComponent<PlayerControllerr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerControllerr.GameOver)
        {
            transform.localPosition += Vector3.left * speedMove * Time.deltaTime;
            transform.Rotate(Vector3.up * gradeRotation * Time.deltaTime);
        }
        
        
    }
}
