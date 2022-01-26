using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject hudcontainer;
    public Text timerText;
    public bool gamePlaying;

    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePlaying = false;

        BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;

        startTime = Time.time;
    }
      

    // Update is called once per frame
    void Update()
    {
        if(gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;
        }
    }
}
