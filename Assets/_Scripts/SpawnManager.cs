using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private Vector3 spawnPos;

    public GameObject[] obstacles;
    private int indexObstacles;

    private float stardelay = 1;
    
    

    [SerializeField, Range(1, 5), Tooltip(" Tiempo de espera para el siguiente spawneo")]
    private float timeRate = 3;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarObstacles", stardelay, timeRate);
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarObstacles()
    {
        if (!_playerController.gameOver)
        {
            indexObstacles = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[indexObstacles], spawnPos, obstacles[indexObstacles].transform.rotation);
        }
        
       

    }
}
