using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class moreo2powerup : MonoBehaviour
{
    private GameManager gamemanger;
    public GameObject player;
    public Image powerupicon;
    public TMP_Text guide;


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
            gamemanger.speed = gamemanger.speed + 8;
            gamemanger.MaxTime = gamemanger.MaxTime + 50;
            Destroy(gameObject);
            player.transform.position = new Vector3(-12, -7, 0);
            powerupicon.enabled = true;
            guide.gameObject.SetActive(true);
            AudioManager.instance.PlaySFX(AudioManager.instance.victory);
            gamemanger.restart();





        }
    }
}