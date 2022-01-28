using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject hudcontainer;
    public Text timerText, countDownText;
    public bool gamePlaying;

    public int countDownTime;
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

        //StartCoroutine(CountdownToStart());
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

    IEnumerator CountdownToStart()
    {
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;

        }

        BeginGame();
        countDownText.text = "PLAY BALL!";

        yield return new WaitForSeconds(0.5f);

        countDownText.gameObject.SetActive(false);
    }
}
