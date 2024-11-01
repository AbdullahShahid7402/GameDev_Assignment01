using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Animator timerAnimations;
    bool noTouch;
    public static int touchcount;
    public Text Timer_Text;
    public Text Score_Text;
    public Text HighScore_Text;
    private float timer;
    private int highscore;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",0);
        }
        highscore = PlayerPrefs.GetInt("HighScore");
        noTouch = true;
        touchcount = 0;
        timer = 15;
        // this is just to ensure 50th second stays on the timer aswell
        timer += 0.999f;
        Timer_Text.text = float_to_int(timer).ToString();
        Score_Text.text = touchcount.ToString();
        HighScore_Text.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer_Logic();
        Tap_Logic();
        highscore_Logic();
        timerAnimations_Management();
    }
    private void timerAnimations_Management()
    {
        timerAnimations.SetFloat("Timer",timer);
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
    private void highscore_Logic()
    {
        if(touchcount>highscore)
        {
            highscore = touchcount;
            PlayerPrefs.SetInt("HighScore",highscore);
            HighScore_Text.text = highscore.ToString();
        }
    }
    private void Tap_Logic()
    {
        if(float_to_int(timer) == 0)
            return;
        Score_Text.text = touchcount.ToString();
        if( noTouch && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
        {
            noTouch = false;
            touchcount++;
        }
        else if ( !noTouch && (Input.touchCount == 0 || Input.GetMouseButtonUp(0)))
        {
            noTouch = true;
        }
    }
    private int float_to_int(float x)
    {
        int y = (int)x;
        return y;
    }
}
