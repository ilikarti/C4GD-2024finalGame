using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moreo2powerup : MonoBehaviour
{
    private GameManager gamemanger;
    public GameObject player;
    public Image powerupicon;


    // Start is called before the first frame update
    void Start()
    {
        gamemanger = GameObject.Find("GameManager").GetComponent<GameManager>();
        powerupicon.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamemanger.speed = gamemanger.speed + 5;
            gamemanger.MaxTime = gamemanger.MaxTime + 75;
            Destroy(gameObject);
            player.transform.position = new Vector3(-12, -7, 0);
            powerupicon.enabled = true;





        }
    }
}