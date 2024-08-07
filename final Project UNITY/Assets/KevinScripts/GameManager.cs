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
    public TMP_Text speedtext;
    public TMP_Text maxoxygen;
    public float time = 100;
    public int wholeTime;
    public float MaxTime;
    public Image O2Bar;
    public float refillSpeed = 4;
    public float speed = 20;
    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
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
        time = 30;
        gameoverGUI.gameObject.SetActive(false);
        player.transform.position = new Vector3(-12, -7, 0);

    }
}
