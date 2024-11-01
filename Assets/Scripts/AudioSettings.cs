using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public static float volume;
    public Slider Volume_Slider;
    
    void Awake()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume",1f);
        }
        volume = PlayerPrefs.GetFloat("Volume");

        Volume_Slider.value = volume;
    }

    void Update()
    {
        if(Volume_Slider.value != volume)
        {
            volume = Volume_Slider.value;
            PlayerPrefs.SetFloat("Volume",volume);
            PlayerPrefs.Save();
        }
    }
}
