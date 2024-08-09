using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; //!
using UnityEngine.Rendering.Universal; //!

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance; //Singleton

    //[Header("name")] is just syntax for formatting a section in the unity inspector

    [Header("Settings")]
    public bool VFXOn = true; //so we can disable and enable the vfx

    [Header("Particles")] //Just storing the prefabs here for easy access
    public GameObject particleSwim;
    Vignette vignette;
    ChromaticAberration Chrome;

    [Header("Screen Effects")] //Post processing
    public Volume volume; //A volume handles post processing effects in Unity
    // Start is called before the first frame update
    void Start()
    {
        volume.gameObject.SetActive(VFXOn);
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ChromaticAberration>(out Chrome);
        instance = this; //Setting the singleton

    }

    //Function to shake the camera by duration and amoun

    //Function to flash damage on screen
    public void LowOxegen(float Vintense, float Cintense)
    {
        if (VFXOn)
        {
            vignette.intensity.value = Vintense;
            Chrome.intensity.value = Cintense;
        }
    }

    //Function to spawn an explosion (realistically this would be a function/line in another script, but I'm putting it here to consolidate everything
    public void SpawnSwim(Vector3 position)
    {
        if (VFXOn)
        {
            Instantiate(particleSwim, position, particleSwim.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Shake


    }
}