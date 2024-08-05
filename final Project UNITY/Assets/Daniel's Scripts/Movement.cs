using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20;
    public float rotateSpeed = 5;
    public Rigidbody2D myrigidbody;
    public Vector3 left = new Vector3(0,0,80);
    public Vector3 right = new Vector3(0, 0, -80);
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myrigidbody.AddForce(transform.right * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            myrigidbody.AddForce(transform.right * -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(left*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(right*Time.deltaTime);
        }
    }
}
