using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Control : MonoBehaviour
{
    [SerializeField] Slider slider;
    void Start()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
        Load();

    }
    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
    }

    public void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
