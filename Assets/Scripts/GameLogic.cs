using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public AudioClip[] TapSounds;
    public GameObject[] ScouterStuff;
    public GameObject Tap_Player;
    public static bool paused;  
    public Animator timerAnimations;
    bool noTouch;
    public static int touchcount;
    public Text Timer_Text;
    public Text Score_Text;
    public Text HighScore_Text;
    public static float timer;
    private int highscore;
    private bool started;
    private AudioSource BGM;
    void Awake()
    {
        paused = true;
        started = false;
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",0);
            PlayerPrefs.Save();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        BGM = GetComponent<AudioSource>();
        for(int i = 0; i < ScouterStuff.Length; i++)
        {
            ScouterStuff[i].SetActive(false);
        }
        highscore = PlayerPrefs.GetInt("HighScore");
        noTouch = true;
        touchcount = 0;
        timer = 3;
        // this is just to ensure last second stays on the timer aswell
        timer += 0.999f;
        Timer_Text.text = float_to_int(timer).ToString();
        Score_Text.text = touchcount.ToString();
        HighScore_Text.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        BGM.volume = AudioSettings.volume;
        StartTimer();
        Timer_Logic();
        Tap_Logic();
        if(Score_Text.text != touchcount.ToString())
        {
            AudioSource temp = Tap_Player.GetComponent<AudioSource>();
            int index = UnityEngine.Random.Range(0,TapSounds.Length);
            temp.clip = TapSounds[index];
            temp.Play();
            Score_Text.text = touchcount.ToString();
        }
        highscore_Logic();
        timerAnimations_Management();
    }
    private void timerAnimations_Management()
    {
        timerAnimations.SetFloat("Timer",timer);
    }
    private void StartTimer()
    {
        if(started)
            return;
        if(timer >= 1f)
        {
            timer -= Time.deltaTime;
            Timer_Text.text = float_to_int(timer).ToString();
            if(timer < 1)
            {
                timer = 15;
                timer += 0.999f;
                for(int i = 0; i < ScouterStuff.Length; i++)
                {
                    ScouterStuff[i].SetActive(true);
                }
                paused = false;
                started = true;
            }
        }
    }
    private void Timer_Logic()
    {
        if(!started)
            return;
        if(paused)
            return;
        if(timer >= 1f)
        {
            timer -= Time.deltaTime;
            Timer_Text.text = float_to_int(timer).ToString();
            if(timer < 1)
            {
                for(int i = 1; i < ScouterStuff.Length; i++)
                {
                    ScouterStuff[i].SetActive(false);
                }
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
            PlayerPrefs.Save();
        }
    }
    private void Tap_Logic()
    {
        if(!started)
            return;
        if(float_to_int(timer) == 0)
            return;
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
