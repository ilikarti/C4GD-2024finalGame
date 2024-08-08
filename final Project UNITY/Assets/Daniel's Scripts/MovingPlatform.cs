using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5;
    public bool movingRight = true;
    public float maxx = 100;
    public float minx = 60;

    void Update()
    {
        if (movingRight && transform.position.x >= maxx)
        {
            movingRight = false; 
        }
  
        else if (!movingRight && transform.position.x <= minx)
        {
            movingRight = true; 
        }

        if (movingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if(!movingRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime *  speed);
        }
    }
}


