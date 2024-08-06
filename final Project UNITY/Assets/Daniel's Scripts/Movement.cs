using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public TMP_Text noo2;
    public bool isDashing = false;
    
   
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
            isDashing = true;
        }
        else 
        {
            timer = 0;
            isDashing = false;
        }
        if (timer > 1.5 &&(gamemanger.time>5))
        {
            timer = 0;
            gamemanger.time = gamemanger.time - 5;
            myrigidbody.AddForce(transform.right * dashSpeed);
        }
        
        else if (timer>1.5 && (gamemanger.time < 5))
        {
            noo2.text = ("Not Enough O2");
            isDashing = false;
        }
        else
        {
            noo2.text = (" ");
        }
    }
}
