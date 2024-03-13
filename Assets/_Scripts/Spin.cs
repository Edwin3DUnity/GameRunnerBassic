using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField, Range(0, 20), Tooltip("Velocidad de moviento")]
    private float speedMove = 6;

    [SerializeField, Tooltip("Rotacion del objeto")]
    private float rotacionGrade = 360;


    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        {
             transform.localPosition += Vector3.left * speedMove * Time.deltaTime;
             
             transform.Rotate(Vector3.up * rotacionGrade * Time.deltaTime);
            
            
        }
        
        
    }
}
