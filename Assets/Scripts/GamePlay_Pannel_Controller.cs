using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay_Pannel_Controller : MonoBehaviour
{
    public GameObject Gameplay_Pannel, Pause_Pannel;
    // Start is called before the first frame update
    void Start()
    {
        Reset_Pannels();
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
        GameLogic.touchcount--;
    }
    public void MainMenu()
    {
        // Go back to the main menu scene
        SceneManager.LoadScene("MainMenu");
        GameLogic.touchcount--;
    }
    public void Reset()
    {
        // Go back to the main menu scene
        SceneManager.LoadScene("Gameplay");
        GameLogic.touchcount--;
    }
}
