using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformY : MonoBehaviour
{
    public float speed = 5;
    public bool movingUp = true;
    public float maxy = 100;
    public float miny = 60;

    void Update()
    {
        if (movingUp && transform.position.y >= maxy)
        {
            movingUp = false; 
        }
  
        else if (!movingUp && transform.position.y <= miny)
        {
            movingUp = true; 
        }

        if (movingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime *  speed);
        }
    }
}


