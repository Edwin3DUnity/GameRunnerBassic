using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacle;

    private Vector3 posSpawn;


    private float startDaley = 1;
    [SerializeField, Range(0, 5)] private float SpwanNextTime = 1.5f;


    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {

        posSpawn = transform.position;
        InvokeRepeating("GenerarObstacles", startDaley, SpwanNextTime);

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
            indexObstacle = Random.Range(0, obstacles.Length );

            Instantiate(obstacles[indexObstacle], posSpawn, obstacles[indexObstacle].transform.rotation);

        }
 
        
        

    }
    
    
}
