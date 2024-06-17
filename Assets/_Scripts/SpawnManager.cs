using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private int indexObstacles;


    [SerializeField, Range(0, 5), Tooltip("Tiempo de espera inicial del primer obstaculo")]
    private float timefirtsObstacle = 1;

    [SerializeField, Range(0, 5), Tooltip("tiempo espera siguiente obstaculo ")]
    private float timeNextObstacle = 2;


    private Vector3 spawnPos;

    private PlayerCOntrooller _playerCOntrooller;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        InvokeRepeating("GenerarObstacles", timefirtsObstacle, timeNextObstacle);
        _playerCOntrooller = GameObject.Find("Player").GetComponent<PlayerCOntrooller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerarObstacles()
    {
        if (!_playerCOntrooller.GameOver)
        {
            indexObstacles = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[indexObstacles], spawnPos, obstacles[indexObstacles].transform.rotation);

        }
      
    }
}
