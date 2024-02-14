using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{

    private Vector3 starPos;
    private float widhgtBackground;
    
    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position;
        widhgtBackground = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (starPos.x - transform.position.x > widhgtBackground)
        {
            transform.position = starPos;
        }
    }
}
