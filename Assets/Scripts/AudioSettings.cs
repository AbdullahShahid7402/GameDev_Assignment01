using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public static float volume;
    public static int Unmute_factor;
    public Slider Volume_Slider;
    public GameObject mute,unmute;
    
    void Awake()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume",1f);
        }
        if(!PlayerPrefs.HasKey("UnMute Factor"))
        {
            PlayerPrefs.SetFloat("UnMute Factor",1);
        }
        PlayerPrefs.Save();
        
        volume = PlayerPrefs.GetFloat("Volume");
        Unmute_factor = PlayerPrefs.GetInt("UnMute Factor");

        Volume_Slider.value = volume;
    }

    void Update()
    {
        if(Unmute_factor == 1)
        {
            unmute.SetActive(true);
            mute.SetActive(false);
        }
        else
        {
            mute.SetActive(true);
            unmute.SetActive(false);
        }
        
        if(Volume_Slider.value != volume)
        {
            volume = Volume_Slider.value;
            PlayerPrefs.SetFloat("Volume",volume);
            PlayerPrefs.Save();
        }
        if(PlayerPrefs.GetInt("UnMute Factor") != Unmute_factor)
        {
            PlayerPrefs.SetInt("UnMute Factor",Unmute_factor);
            PlayerPrefs.Save();
        }
    }
}
