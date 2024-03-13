using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacles;


    private Vector3 spawnPos;

    private float startDelay = 1;

    [SerializeField, Range(0, 5), Tooltip("tiempo de espera para el siguiente spwaneo")]
    private float spawnNextTime = 2;

    private ControladorPlayer _controladorPlayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarObstacles", startDelay, spawnNextTime);
        _controladorPlayer = GameObject.Find("Player").GetComponent<ControladorPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void GenerarObstacles()
    {
        if (!_controladorPlayer.GameOver)
        {
            indexObstacles = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[indexObstacles], spawnPos, obstacles[indexObstacles].transform.rotation);
        }
        

    }
    
}
