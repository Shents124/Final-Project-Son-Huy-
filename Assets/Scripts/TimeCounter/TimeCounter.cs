using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    private const string TimeBegin = "00:00.00";
    private const string TimePlayingHeader = "Time: ";
    private const string TimePlayingFormat = "mm':'ss'.'ff";
    
    public Text timeCounter;

    private TimeSpan timePlaying;

    private float elapsedTime;
    public bool isGamePlaying = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        timeCounter.text = TimePlayingHeader + TimeBegin;
    }

    private void Update()
    {
        CountingTime();
    }

    private void CountingTime()
    {
        if (isGamePlaying)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timeCounter.text = TimePlayingHeader + timePlaying.ToString(TimePlayingFormat);
        }
    }
}
