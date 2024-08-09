using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class powerUp : MonoBehaviour
{
    public Image powerupicon;
    public GameObject player;
    private GameManager gamemanger;
    //public TMP_Text infobar;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamemanger.speed = gamemanger.speed + 6;
            gamemanger.rotateSpeed = gamemanger.rotateSpeed + 0.3f;
            Destroy(gameObject);
            powerupicon.enabled = true;
            player.transform.position = new Vector3(-12, -7, 0);
            AudioManager.instance.PlaySFX(AudioManager.instance.victory);
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



