using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos;

    public GameObject[] obstacles;
    private int indexObstacles;

    private float firstObstacleTime = 1;

    [SerializeField, Range(1, 5), Tooltip("Tiempo de espera para el siguiente spwan ")]
    private float nextObstacleRate = 1.5f;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarObstacles", firstObstacleTime, nextObstacleRate);
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarObstacles()
    {

        if (_playerController.GameOver == false)
        {
            indexObstacles = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[indexObstacles], spawnPos, obstacles[indexObstacles].transform.rotation);
        }
        


    }
}
