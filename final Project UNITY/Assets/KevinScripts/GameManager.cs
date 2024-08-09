using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundCalm;
    public AudioSource backgroundIntense;
    public AudioSource lose;
    public GameObject player;
    public BreathingArea breathingarea;
    public GameObject gameoverGUI;
    public TMP_Text O2Text;
    public float time = 75;
    public int wholeTime;
    public float MaxTime;
    public Image O2Bar;
    public float refillSpeed = 18;
    public float speed = 15;
    public float rotateSpeed = 1.2f;
    public bool isActive = true;
    public AudioSource calmMusic;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public Rigidbody2D rb4;
    //Rigid bodys are TOP to BOTTOM
    public Rigidbody2D badwall1;
    public Rigidbody2D badwall2;
    public Rigidbody2D badwall3;

    // Start is called before the first frame update
    void Start()
    {
        restart();
        time = MaxTime;
        wholeTime = (int)time;
        O2Text.text = "O2 " + wholeTime;
        gameoverGUI.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        O2Text.text = "O2 " + (int)time;
        if (time > 0 && breathingarea.inSafeArea == false)
        {
            time -= Time.deltaTime;
            O2Bar.fillAmount = time / MaxTime;
            if(time/MaxTime > 0.5f)
            {
                backgroundCalm.volume = (time / MaxTime) * 0.6f;
            }
            else
            {
                backgroundCalm.volume = (time / MaxTime) * time/MaxTime * 0.9f;
            }
            backgroundIntense.volume = 0.4f;
            if (time < 15f)
            {
                backgroundIntense.volume = 1f;
                backgroundIntense.pitch = 0.7f;
            }
            else if (time  < 25f)
            {
                backgroundIntense.volume = 0.8f;
                backgroundIntense.pitch = 0.8f;
            }
            else if (time < 30f)
            {
                backgroundIntense.volume = 0.6f;
                backgroundIntense.pitch = 0.9f;
            }
        }
        if (time < wholeTime)
        {
            wholeTime = (int)time;
            O2Text.text = "O2 " + wholeTime;
        }
        if (time < 0)
        {
            gameover();
        }
        if (breathingarea.inSafeArea == true && time < MaxTime)
        {

            time += Time.deltaTime * refillSpeed;
            O2Bar.fillAmount = time / MaxTime;
            if (time > wholeTime)
            {
                wholeTime = (int)time;
                wholeTime++;

            }
        }
    }
    void gameover()
    {
        gameoverGUI.gameObject.SetActive(true);
        isActive = false;
        lose.time = 0.5f;
        lose.volume = 7f;

    }
    public void restart()
    {
        backgroundCalm.time = 0;
        lose.mute = true;
        lose.volume = 0;
        backgroundCalm.mute = false;
        backgroundCalm.volume = 0.6f;
        time = 50;
        gameoverGUI.gameObject.SetActive(false);
        player.transform.position = new Vector3(-12.91f, 10.06f, 0);
        rock1.transform.position = new Vector3(44f, -55f, 0);
        rock2.transform.position = new Vector3(58f, -69f, 0);
        rb.MovePosition(new Vector3(0.52f, -1.14f, 0));
        rb2.MovePosition(new Vector3(32.96f, -1.20f, 0));
        rb3.MovePosition(new Vector3(40.08f, -21.70f, 0));
        rb4.MovePosition(new Vector3(94f, -98f, 0));
        badwall1.MovePosition(new Vector3(-61.4f, -64.9f, 0));
        badwall2.MovePosition(new Vector3(-59.5f, -86.7f, 0));//fix this with rock pos
        badwall3.MovePosition(new Vector3(-81.4f, -110.34f, 0));// same as above
    }
}
