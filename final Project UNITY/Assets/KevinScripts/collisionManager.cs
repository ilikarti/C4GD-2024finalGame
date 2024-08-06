using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float strength = 5f;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("moveable"))
        {
            Rigidbody2D moveable = other.gameObject.GetComponent<Rigidbody2D>();
            Vector3 awayDirection = ((other.gameObject.transform.position - transform.position).normalized);
            moveable.AddForce(awayDirection * strength, (ForceMode2D)ForceMode.Impulse);
        }
        /*if (other.gameObject.CompareTag("wall"))
        {
            Vector3 awayDirection = (-(other.gameObject.transform.position - transform.position).normalized);
            myrigidbody.AddForce(awayDirection * strength, (ForceMode2D)ForceMode.Impulse);
        }*/
    }
}
