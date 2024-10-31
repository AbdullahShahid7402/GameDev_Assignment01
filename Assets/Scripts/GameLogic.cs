using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Text Timer_Text;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15;
        // this is just to ensure 50th second stays on the timer aswell
        timer += 0.99f;
        Timer_Text.text = float_to_int(timer).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer_Logic();
    }
    private void Timer_Logic()
    {
        if(timer >= 1f)
        {
            timer -= Time.deltaTime;
            Timer_Text.text = float_to_int(timer).ToString();
            if(timer < 1)
            {
                timer = 0.001f;
            }
        }
    }
    private int float_to_int(float x)
    {
        int y = (int)x;
        return y;
    }
}
