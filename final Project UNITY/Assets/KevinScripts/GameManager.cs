using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text O2Text;
    public float time = 10;
    public int wholeTime;
    public float MaxTime;
    public Image O2Bar;
    public float refillSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        MaxTime = time;
        wholeTime = (int)time - 1;
        O2Text.text = "O2 " + wholeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            O2Bar.fillAmount = time/MaxTime;
        }
        else
        { // timer has finished
        }
        if (time < wholeTime)
        {
            wholeTime = (int)time;
            O2Text.text = "O2 " + wholeTime;
        }
        if (Input.GetKey(KeyCode.B) && time < MaxTime)
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
}
