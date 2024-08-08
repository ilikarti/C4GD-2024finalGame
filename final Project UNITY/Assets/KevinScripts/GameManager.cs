using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private BreathingArea breathingarea;
    public GameObject gameoverGUI;
    public TMP_Text O2Text;
    public float time = 75;
    public int wholeTime;
    public float MaxTime;
    public Image O2Bar;
    public float refillSpeed = 18;
    public float speed = 15;
    public bool isActive = true;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public Rigidbody2D rb4;

    // Start is called before the first frame update
    void Start()
    {
        restart();
        breathingarea = GameObject.Find("Breathing Area").GetComponent<BreathingArea>();
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
            O2Bar.fillAmount = time/MaxTime;
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
    }
    public void restart()
    {
        isActive = true;
        time = 50;
        gameoverGUI.gameObject.SetActive(false);
        player.transform.position = new Vector3(-12.91f, 10.06f, 0);
        rock1.transform.position = new Vector3(44f, -55f, 0);
        rock2.transform.position = new Vector3(58f, -69f, 0);
        rb4.MovePosition(new Vector3(106.53f, -123.72f));
        rb.MovePosition(new Vector3(0.52f, -1.14f, 0));
        rb2.MovePosition(new Vector3(32.96f, -1.20f,0));
        rb3.MovePosition(new Vector3(40.08f, -21.70f,0));

    }
}
