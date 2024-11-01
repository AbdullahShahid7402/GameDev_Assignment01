using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public static float volume;
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume",1f);
        }
        volume = PlayerPrefs.GetFloat("Volume");
    }
}
