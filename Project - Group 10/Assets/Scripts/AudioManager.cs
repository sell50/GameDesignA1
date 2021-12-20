using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioClip buttonSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound = Resources.Load<AudioClip>("Audio/buttonClick");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string key)
    {
        switch (key)
        {
            case "press": audioSrc.PlayOneShot(buttonSound); break; 
        }
    }
}
