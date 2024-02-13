using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacles;

    private Vector3 spawnPos;
    private float stardelal = 0;
    [SerializeField ] private float timeRate = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        InvokeRepeating("GenerarObstacles", stardelal, timeRate );
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerarObstacles()
    {
        Instantiate(obstacles[indexObstacles], spawnPos, obstacles[indexObstacles].transform.rotation);
    }
}
