using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft2 : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("velocidad de movimiento")]
    private float speedMov3 = 8;

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
            transform.Translate(Vector3.left * speedMov3 * Time.deltaTime);
        }
        
        
    }
}
