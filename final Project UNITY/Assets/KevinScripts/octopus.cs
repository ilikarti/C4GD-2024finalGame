using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octopus : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private GameObject player;
    public GameManager gameManager;
    public float speed = 20f;
    public bool inRange = false;
    private float distance = 0;
    public float detectRange = 50f;
    public LayerMask playerMask;
    public LayerMask layerMask;
    RaycastHit2D hit;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindObjectOfType<Movement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
    }
    void FireRay()
    {
        Ray2D ray = new Ray2D(transform.position, player.transform.position - transform.position);
        Debug.DrawRay(ray.origin, ray.direction * detectRange);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, detectRange, layerMask);
        RaycastHit2D play = Physics2D.Raycast(ray.origin, ray.direction, detectRange, playerMask);
        if (hit && play)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameManager.time = gameManager.time - 1;

    }
    void FixedUpdate()
    {
        FireRay();
    }
    void Update()
    {
        if(inRange == true)
        {
            Vector3 awayDirection = (-(transform.position - player.transform.position).normalized);
            rb.AddForce(awayDirection * speed);
        }
    }
    // Update is called once per frame
}
