using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacles;

    private Vector3 posSpawn;

    private float startDelay = 1;

    [SerializeField, Range(0, 5), Tooltip("Tiempo de espera para el siguiente spawnweo")]
    private float spwanNextTime = 2;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        posSpawn = transform.position;
         InvokeRepeating("GenerarObstacles", startDelay, spwanNextTime);

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
            indexObstacles = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[indexObstacles], posSpawn, obstacles[indexObstacles].transform.rotation);
        }
        
    



    }
}
