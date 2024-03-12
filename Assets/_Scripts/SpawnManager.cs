using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacles;


    private Vector3 posSpawn;

    private float startDaley = 1;

    [SerializeField] private float spawnNextTime =2;

    private PlayerControlador _playerControlador;
    
    // Start is called before the first frame update
    void Start()
    {

        posSpawn = transform.position;
        
        InvokeRepeating("GenerarObstacles", startDaley, spawnNextTime);

        _playerControlador = GameObject.Find("Player").GetComponent<PlayerControlador>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    private void GenerarObstacles()
    {
        if (!_playerControlador.GameOver)
        {
            indexObstacles = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[indexObstacles], posSpawn, obstacles[indexObstacles].transform.rotation);

        }
       


    }
}
