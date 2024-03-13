using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField, Range(0, 20), Tooltip(" Velocidad de movimiento")]
    public float speedMove = 8.5f;

    [SerializeField, Tooltip("Grados de rotacion")]
    private float rotationGrade = 360;

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
            transform.localPosition += Vector3.left * speedMove * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationGrade * Time.deltaTime);
        }
        
        
    }
}
