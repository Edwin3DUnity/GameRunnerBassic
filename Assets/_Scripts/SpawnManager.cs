using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int indexEnemy;

    private Vector3 spawnPos;


    private float startSpawn = 1;

    [SerializeField, Range(1, 3), Tooltip(" Tiempo de espera para el siguiente enemigo")]
    private float nextEnemy = 2;


    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarEnemigos", startSpawn, nextEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void GenerarEnemigos()
    {
        indexEnemy = Random.Range(0, enemies.Length);

        Instantiate(enemies[indexEnemy], spawnPos, enemies[indexEnemy].transform.rotation);

    }

    
}
