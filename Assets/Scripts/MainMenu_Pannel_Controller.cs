using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenu_Pannel_Controller : MonoBehaviour
{
    public GameObject MainMenu_Pannel, Settings_Pannel, HowToPlay_Pannel, Credits_Pannel;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize_Pannels();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
    public void Settings_button()
    {
        // Settings Button Logic here
        MainMenu_Pannel.SetActive(false);
        Settings_Pannel.SetActive(true);
    }
    public void HowToPlay_button()
    {
        // How To Play Button Logic here
        MainMenu_Pannel.SetActive(false);
        HowToPlay_Pannel.SetActive(true);
    }
    public void Credits_button()
    {
        // Credits Button Logic here
        MainMenu_Pannel.SetActive(false);
        Credits_Pannel.SetActive(true);
    }
    public void BackToMenu_button()
    {
        // Back To Menu Button Logic here
        // already logic exists in initialize pannels function... so might aswell just use it as it is
        Initialize_Pannels();
    }
}
