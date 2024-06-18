using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManaggerr : MonoBehaviour
{
    public GameObject[] obstacles;
    private int indexObstacles;

    private Vector3 posSpawn;

    [SerializeField, Range(0, 5)] private float timeFirtsObstacle = 1;
    [SerializeField, Range(0, 5)] private float nextObstacleTime = 2;

    private PlayerControllerr _playerControllerr;
    
    // Start is called before the first frame update
    void Start()
    {
        posSpawn = transform.position;
        _playerControllerr = GameObject.Find("Player").GetComponent<PlayerControllerr>();
        
        InvokeRepeating("GenerarObstacles", timeFirtsObstacle, nextObstacleTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarObstacles()
    {
        if (!_playerControllerr.GameOver)
        {
            indexObstacles = Random.Range(0, obstacles.Length);


            Instantiate(obstacles[indexObstacles], posSpawn, obstacles[indexObstacles].transform.rotation);
        }
        

    }
    
}
