using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay_Pannel_Controller : MonoBehaviour
{
    public GameObject Pause_Pannel;
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
        Pause_Pannel.SetActive(false);
    }
}
