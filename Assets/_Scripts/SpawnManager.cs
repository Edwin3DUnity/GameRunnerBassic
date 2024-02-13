using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int indexObstacle;

    [SerializeField, Tooltip("Posicion donde van a salir los obstaculos")]
    private Vector3 spawnPos;

    private float stardelay = 1;

  [SerializeField, Range(0, 5)]  private float waitNextObstacle;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarObstaculos", stardelay, waitNextObstacle  );
        //waitNextObstacle = Random.Range(2, 5);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" tiempo de espera es" + waitNextObstacle);
        
    }

    private void GenerarObstaculos()
    {

        indexObstacle = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[indexObstacle],spawnPos, obstacles[indexObstacle].transform.rotation);


    }
    
}
