using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{

    public GameObject[] obstaculos;
    private int indexObstacles;


    private Vector3 posSpawn;


    private float starDelay = 1;

    [SerializeField, Range(0, 5), Tooltip("tiemop de espera para el siguiente spawneo")]
    private float nextSpawnTime = 2;


    private PlayerController _playerController;



    
    
    
    // Start is called before the first frame update
    void Start()
    {
        posSpawn = transform.position;
        
        InvokeRepeating("GenerarObstaculos", starDelay, nextSpawnTime);

        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerarObstaculos()
    {

        if (!_playerController.GameOver)
        {
            indexObstacles = Random.Range(0, obstaculos.Length);

            Instantiate(obstaculos[indexObstacles], posSpawn, obstaculos[indexObstacles].transform.rotation);

        }
      
        
        




    }
}
