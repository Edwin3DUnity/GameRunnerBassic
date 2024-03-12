using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("velocidad de movimiento")]
    private float moveSpeed = 7;

    [SerializeField, Range(0, 20), Tooltip("grados de rotacion")]
    private float rotacionGrade = 380;


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
            transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up * rotacionGrade * Time.deltaTime);
        }
    }
}
