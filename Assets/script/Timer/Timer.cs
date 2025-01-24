using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerDisplay;
    [SerializeField] TextMeshProUGUI bestTimeDisplay;
    float time;
    float bestTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", 43200f);
        bestTimeDisplay.text = SetTimeFormat(bestTime);
        time = 0;
        timerDisplay.text = SetTimeFormat(time);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerDisplay.text = SetTimeFormat(time);
    }


    public string SetTimeFormat(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        
        return timeSpan.ToString(@"hh\:mm\:ss");
    }

    public void SaveTime()
    {
        if (bestTime > time) 
        { 
            PlayerPrefs.SetFloat("BestTime",time);
        }
    }
}
