using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    private float startTime;
    private float endTime;
    private bool timerRunning = false;

    private void Awake()
    {
        // Ensure this object persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Only one instance should exist
        }
    }

    private void Start()
    {
        // Start the timer when the first scene loads
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerRunning = true;
    }

    public string StopTimer()
    {
        if (timerRunning)
        {
            endTime = Time.time;
            timerRunning = false;
            float totalTime = endTime - startTime;

            TimeSpan timeSpan = TimeSpan.FromSeconds(totalTime);
            string formattedTime = string.Format("{0:D2}.{1:D2}.{2:D2}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

            
            Debug.Log("Total Time Taken: " + formattedTime);
            return formattedTime; // Return the total time in HH:MM:SS format
        }
        return "00.00.00"; // Return default time if timer was not running
    }
}
