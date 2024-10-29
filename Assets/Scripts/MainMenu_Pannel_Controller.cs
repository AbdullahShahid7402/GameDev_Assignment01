using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenu_Pannel_Controller : MonoBehaviour
{
    public GameObject MainMenu_Pannel;
    
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
    }
}
