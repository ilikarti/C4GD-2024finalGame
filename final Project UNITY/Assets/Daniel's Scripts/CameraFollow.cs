using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = 7;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.M) && Camera.main.orthographicSize == 20)
        {
            Camera.main.orthographicSize = 7;
        }
        else if (Input.GetKeyDown(KeyCode.M) && Camera.main.orthographicSize == 7)
        {
            Camera.main.orthographicSize = 20;
        }
    }



}