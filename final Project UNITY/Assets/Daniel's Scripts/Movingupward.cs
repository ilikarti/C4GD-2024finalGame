using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingupward : MonoBehaviour
{
    public float speedup = 5;
    public bool movingup = true;
    public float maxy = 100;
    public float miny = 60;

    void Update()
    {
        if (movingup && transform.position.y >= maxy)
        {
            movingup = false; 
        }
  
        else if (!movingup && transform.position.y <= miny)
        {
            movingup = true; 
        }

        if (movingup)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedup);
        }
        else if(!movingup)
        {
            transform.Translate(Vector3.down * Time.deltaTime *  speedup);
        }
    }
}


