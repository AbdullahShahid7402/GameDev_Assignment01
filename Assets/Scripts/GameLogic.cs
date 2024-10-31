using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Text Timer_Text;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 50;

        Timer_Text.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
