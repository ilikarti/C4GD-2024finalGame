using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject wall;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            wall.SetActive(false);
        }
        else
        {
            wall.SetActive(true);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("moveable"))
        {
            isActive = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("moveable"))
        {
            isActive = false;
        }
    }
}
