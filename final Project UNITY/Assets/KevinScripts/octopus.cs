using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octopus : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private GameObject player;
    public float speed = 0.2f;
    private float distance = 0;
    public bool inRange = false;
    public bool attackRange = false;
    //Target.position - current position + mag 1 will give the direction to the target
    void Start()
    {
        player = GameObject.FindObjectOfType<Movement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
    }
    void track()
    {
        if (inRange == true && attackRange == true)
        {
            Vector3 towardPlayer = (player.transform.position - transform.position).normalized;
            rb.AddForce((towardPlayer * speed));
        }
        else if (inRange == true )
        {
            Vector3 towardPlayer = (player.transform.position - transform.position).normalized;
            rb.AddForce((towardPlayer * speed));
        }
        
        else
        {
            inRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 5)
        {
            attackRange = true;
        }
        else if (distance <= 20)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        track();
    }
}
