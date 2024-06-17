using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spin : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("velocidad de rotacion")]
    private float speedLeft = 5;

    [SerializeField, Tooltip("Grados de rotacion")]
    private float rotationGrade = 360;

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
            transform.localPosition += Vector3.left * speedLeft * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationGrade * Time.deltaTime);
        }
       
    }
}
