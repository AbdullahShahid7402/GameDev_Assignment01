using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_Pannel_Controller : MonoBehaviour
{
    public GameObject MainMenu_Pannel, Settings_Pannel, HowToPlay_Pannel, Credits_Pannel;
    private AudioSource audio_source;
    public GameObject button_audio_source;
    private AudioSource button_audio;
    
    // Start is called before the first frame update
    void Start()
    {
        // Reset_PlayerPrefs();
        Initialize_Pannels();
        audio_source = GetComponent<AudioSource>();
        audio_source.volume = AudioSettings.volume;
        button_audio = button_audio_source.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio_source.volume = AudioSettings.volume * AudioSettings.Unmute_factor;
        button_audio.volume = AudioSettings.volume;
    }

    // just call this in main menu to remove all player saved data
    private void Reset_PlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    // Initialize all Pannels' Active Status Here
    private void Initialize_Pannels()
    {
        MainMenu_Pannel.SetActive(true);
        Settings_Pannel.SetActive(false);
        HowToPlay_Pannel.SetActive(false);
        Credits_Pannel.SetActive(false);
    }

    public void Play_button()
    {
        // Play Button Logic here
        SceneManager.LoadScene("Gameplay");
        button_audio.Play();
    }
    public void Settings_button()
    {
        // Settings Button Logic here
        // MainMenu_Pannel.SetActive(false);
        var anim1 = MainMenu_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Right Move");
        Settings_Pannel.SetActive(true);
        button_audio.Play();
    }
    public void HowToPlay_button()
    {
        // How To Play Button Logic here
        // MainMenu_Pannel.SetActive(false);
        var anim1 = MainMenu_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Up Move");
        HowToPlay_Pannel.SetActive(true);
        button_audio.Play();
    }
    public void Credits_button()
    {
        // Credits Button Logic here
        // MainMenu_Pannel.SetActive(false);
        var anim1 = MainMenu_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Down Move");
        Credits_Pannel.SetActive(true);
        button_audio.Play();
    }

    public void Remove_HighScore_Click()
    {
        PlayerPrefs.SetInt("HighScore",0);
        PlayerPrefs.Save();
        button_audio.Play();
    }
    public void Mute_Click()
    {
        AudioSettings.Unmute_factor = 1;
        button_audio.Play();
    }

    public void Unmute_Click()
    {
        AudioSettings.Unmute_factor = 0;
        button_audio.Play();
    }
    public void BackToMenu_button()
    {
        // Back To Menu Button Logic here
        // already logic exists in initialize pannels function... so might aswell just use it as it is
        
        var anim1 = MainMenu_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Go Back");
        anim1 = Settings_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Go Back");
        anim1 = HowToPlay_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Go Back");
        anim1 = Credits_Pannel.GetComponent<Animator>();
        anim1.SetTrigger("Go Back");
        Invoke("Initialize_Pannels",1f);
        button_audio.Play();
    }
}
