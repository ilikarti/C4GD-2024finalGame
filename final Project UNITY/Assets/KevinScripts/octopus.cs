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
    public LayerMask layerMask;
    RaycastHit2D hit;
    void Start()
    {
        player = GameObject.FindObjectOfType<Movement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
    }
    void FireRay()
    {
        Ray2D ray = new Ray2D(transform.position, player.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 5.0f, layerMask);
        if (hit && hit.distance < 20)
        {
            print(Vector3.Distance(hit.transform.position, transform.position));

        }
        Debug.DrawRay(ray.origin, ray.direction * 20);

    }
    void FixedUpdate()
    {
        FireRay();
    }
        // Update is called once per frame
}
