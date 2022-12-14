using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class winStageTimeCounting : MonoBehaviour
{
    float Time;
    float minutes;
    float seconds;
    public TextMeshProUGUI secondsCount;
    public TextMeshProUGUI minutesCount;
    public TextMeshProUGUI minutesText;
    public TextMeshProUGUI secondsText;

    // Start is called before the first frame update
    void Start()
    {
        Time = PlayerPrefs.GetFloat("TimerPrefs");
        TimeSpan time = TimeSpan.FromSeconds(Time);
        seconds = time.Seconds;
        minutes = time.Minutes;
    }

    // Update is called once per frame
    void Update()
    {
        secondsCount.text = seconds.ToString();
        minutesCount.text = minutes.ToString();
        if(minutes > 1)
        {
            minutesText.text = "minutes";
        }
        else
        {
            minutesText.text = "minute";
        }

        if(seconds > 1)
        {
            secondsText.text = "seconds";
        }
        else
        {
            secondsText.text = "second";
        }
    }
}
