using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private int indesxObstalces;

   [SerializeField] private Vector3 posSpawn;

   private float stardlay = 1;
   [SerializeField, Range(0, 5)] private float waitRate; 
   
    // Start is called before the first frame update
    void Start()
    {
        posSpawn = transform.position;
        
        InvokeRepeating("GenerarObstaculos", stardlay, waitRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarObstaculos()
    {
        indesxObstalces = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[indesxObstalces], posSpawn, obstacles[indesxObstalces].transform.rotation);


    }
    
    
}
