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
    public float dashSpeed = 100000;
    public float timer = 0;
    private GameManager gamemanger;
   
    // Start is called before the first frame update
    void Start()
    {
        gamemanger = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
        }
        else 
        {
            timer = 0;
        }

        if (timer > 1.5)
        {
            timer = 0;
            print("Dashing");
            gamemanger.time = gamemanger.time - 5;
            myrigidbody.AddForce(transform.right * dashSpeed);
        }
    }
}
