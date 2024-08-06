using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = 9;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.M) && Camera.main.orthographicSize == 9)
        {
            Camera.main.orthographicSize = 30;
        }
        else if (Input.GetKeyDown(KeyCode.M) && Camera.main.orthographicSize == 30)
        {
            Camera.main.orthographicSize = 9;
        }
    }



}