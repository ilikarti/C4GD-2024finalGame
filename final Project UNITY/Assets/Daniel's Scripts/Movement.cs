using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public ParticleSystem partcles;
    public GameObject groundEffectPrefab;
    public Vector3 left = new Vector3(0,0,80);
    public Vector3 right = new Vector3(0, 0, -80);
    public float dashSpeed = 100000;
    public float timer = 0;
    private GameManager gamemanger;
    public TMP_Text noo2;
    public bool isDashing = false;
    public bool startTimer = false;
    public float strength = 50f;
    public float timer2 = 0;
    public float triggertime = 0.2f;
    
   
    // Start is called before the first frame update
    void Start()
    {
        gamemanger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)&& gamemanger.isActive == true)
        {
            myrigidbody.AddForce(transform.right * gamemanger.speed);
        }

        if (Input.GetKey(KeyCode.S) && gamemanger.isActive == true)
        {
            myrigidbody.AddForce(transform.right * -gamemanger.speed);
        }
        if (Input.GetKey(KeyCode.A) && gamemanger.isActive == true)
        {
            transform.Rotate(left * Time.deltaTime * gamemanger.rotateSpeed);

        }
        if (Input.GetKey(KeyCode.D) && gamemanger.isActive == true)
        {
            transform.Rotate(right * Time.deltaTime * gamemanger.rotateSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && gamemanger.isActive == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            isDashing = false;
        }
            if (timer > 1)
        {
            myrigidbody.AddForce(transform.right * dashSpeed );
            isDashing = true;
            gamemanger.time = gamemanger.time - 1;
            timer = 0;
            StartCoroutine(dashTime());

        }

        else if (timer > 1.5 && (gamemanger.time < 5))
        {
           noo2.text = ("Not Enough O2");
        }
        else
        {
            noo2.text = (" ");
        }
        if(startTimer == true)
        {
            timer2 += Time.deltaTime;
        }
        if(timer2 > 0.5f)
        {
            startTimer = false;
        }
    }
        IEnumerator dashTime()
        {
            yield return new WaitForSeconds(0.5f);
            isDashing = false;
        }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(isDashing == true)
        {
            Instantiate(groundEffectPrefab, transform.position, other.transform.rotation);
        }
        if ((other.gameObject.CompareTag("moveable") || other.gameObject.CompareTag("Rock")) && isDashing == true)
        {
            Rigidbody2D moveable = other.gameObject.GetComponent<Rigidbody2D>();
            AudioManager.instance.PlaySFX(AudioManager.instance.dashing);
            Vector3 awayDirection = ((other.gameObject.transform.position - transform.position).normalized);
            moveable.AddForce(awayDirection * strength, (ForceMode2D)ForceMode.Impulse);
        }
        if(other.gameObject.CompareTag("Spike"))
        {

            
             gamemanger.time = (gamemanger.time - 3);
             Vector3 awayDirection = ((other.gameObject.transform.position - transform.position).normalized);
             myrigidbody.AddForce(-awayDirection *50, (ForceMode2D)ForceMode.Impulse);
             timer2 = 0;
             startTimer = true;
             AudioManager.instance.PlaySFX(AudioManager.instance.pushingBoulder);
            
        }
        
    }
    
   

}
