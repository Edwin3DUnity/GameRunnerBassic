using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMangeer : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacles;

    private Vector3 posSpawn;


    private float startDelay = 1;

    [SerializeField, Range(0, 5), Tooltip("Tiempo para spawnear el siguiente obstaculo")]
    private float ObstaclesrateTime = 1.2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        posSpawn = transform.position;

        InvokeRepeating("GenerarObstaculos", startDelay, ObstaclesrateTime);    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarObstaculos()
    {
        indexObstacles = Random.Range(0, obstacles.Length);


        Instantiate(obstacles[indexObstacles], posSpawn, obstacles[indexObstacles].transform.rotation);


    }
    
}
