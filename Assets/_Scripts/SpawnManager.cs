using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private int indexObstables;

    private Vector3 spawnPos;

    private float startDelay = 1;

    [SerializeField, Range(0, 5), Tooltip("Tiempo de espera para el siguiente spawneo")]
    private float spawnNextTime = 2;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarObstacles", startDelay, spawnNextTime);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarObstacles()
    {
        if (!_playerController.GameOver)
        {
            indexObstables = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[indexObstables], spawnPos, obstacles[indexObstables].transform.rotation);
        }
        
    }
    
}
