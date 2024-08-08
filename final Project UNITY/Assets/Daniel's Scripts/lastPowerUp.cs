using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastPowerUp : MonoBehaviour
{
    public GameManager gamemanger;
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
            if (gamemanger.MaxTime>=175 && gamemanger.speed > 30)
            {
                Destroy(gameObject);

            }
          


        }
    }
    public void endGame()
    {

    }
}