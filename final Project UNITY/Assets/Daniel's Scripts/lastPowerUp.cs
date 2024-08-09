using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lastPowerUp : MonoBehaviour
{
    private GameManager gamemanger;
    public GameObject victory;
    // Start is called before the first frame update
    void Start()
    {
        gamemanger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gamemanger.MaxTime>=120 && gamemanger.speed >= 20)
            {
                Destroy(gameObject);
                
            }
            victory.SetActive(true);
            print("working");


        }
    }
    public void endGame()
    {

    }
}