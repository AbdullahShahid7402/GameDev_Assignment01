using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay_Pannel_Controller : MonoBehaviour
{
    public GameObject Gameplay_Pannel, Pause_Pannel;
    public GameObject button_audio_source;
    private AudioSource button_audio;
    // Start is called before the first frame update
    void Start()
    {
        Reset_Pannels();
        button_audio = button_audio_source.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Reset_Pannels()
    {
        Gameplay_Pannel.SetActive(true);
        Pause_Pannel.SetActive(false);
    }

    public void Pause_Button()
    {
        GameLogic.paused = !GameLogic.paused;
        // Pause Button displays pause pannel and hide main pannel
        // Gameplay_Pannel.SetActive(!Gameplay_Pannel.activeSelf);
        Pause_Pannel.SetActive(!Pause_Pannel.activeSelf);
        // if(!GameLogic.paused)
        //     GameLogic.touchcount--;
        button_audio.Play();
    }
    public void MainMenu()
    {
        // Go back to the main menu scene
        SceneManager.LoadScene("MainMenu");
        GameLogic.touchcount--;
        button_audio.Play();
    }
    public void Reset()
    {
        // Go back to the main menu scene
        SceneManager.LoadScene("Gameplay");
        GameLogic.touchcount--;
        button_audio.Play();
    }
}
