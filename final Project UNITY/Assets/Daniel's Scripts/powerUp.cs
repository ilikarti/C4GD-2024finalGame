using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class powerUp : MonoBehaviour
{
    private GameManager gamemanger;
    //public TMP_Text infobar;
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
        print("yes");
        if (collision.CompareTag("Player"))
        {
            gamemanger.speed = gamemanger.speed + 10;
            gamemanger.MaxTime = gamemanger.MaxTime + 10;
            Destroy(gameObject);
            //infobar.text = ("+10 Speed + 10 Max O2");
            //StartCoroutine(hideTime());



        }
        //IEnumerator hideTime()
        //{
           // yield return new WaitForSeconds(3f);
            //.text = " ";
       // }

    }
}



