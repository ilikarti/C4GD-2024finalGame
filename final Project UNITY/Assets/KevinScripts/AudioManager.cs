using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; //singleton
    private AudioSource source;
    public AudioClip goingDown, pushingBoulder, swimming, victory, lose;
    // Start is called before the first frame update
    public void PlaySFX(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
