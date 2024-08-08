using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    public Vector3 stop1;
    public Vector3 stop2;
    public float speed;
    private float storage;
    public float wait;
    public int st1or2 = 2;
    public Rigidbody2D rb;
    public bool RorL;
    public bool UorD;
    // Start is called before the first frame update
    void Start()
    {
        stop1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(st1or2 == 1 && ((transform.position.x >= stop1.x)))
        {
            StartCoroutine(platWait());
            st1or2 = 3 - st1or2;
        }
        else if (st1or2 == 2 && (transform.position.normalized == stop2))
        {
            StartCoroutine(platWait());
            st1or2 = 3 - st1or2;
        }
        else if (st1or2 == 1)
        {
            rb.AddForce((stop1-stop2).normalized * speed);
        }
        else if (st1or2 == 2)
        {
            rb.AddForce((stop2-stop1).normalized * speed);
        }
    }
    IEnumerator platWait()
    {
        yield return new WaitForSeconds(wait);
    }
}
