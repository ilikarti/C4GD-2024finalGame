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
    }

    // Update is called once per frame
    void Update()
    {

        Vector3.Lerp(stop1, stop2, 4);
        Vector3.Lerp(stop2, stop1, 4);
    }

}
