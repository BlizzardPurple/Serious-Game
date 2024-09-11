using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMuteUnmute : MonoBehaviour
{
    // Singleton instance
    public static GlobalMuteUnmute instance;

    // Static global mute state
    private static bool isMutedGlobally = false;

    // Awake method to enforce the Singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject);  // Prevent duplicate instances
        }
    }

    // Update method to handle toggling mute/unmute using the "M" key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();  // Toggles the mute state
            Debug.Log("M key pressed");
            Debug.Log("isMutedGlobally: " + isMutedGlobally);
        }
    }

    // Method to toggle the global mute state
    public void ToggleMute()
    {
        isMutedGlobally = !isMutedGlobally;  // Toggle the mute state

        if (isMutedGlobally)
        {
            AudioListener.volume = 0;  // Mute all audio
        }
        else
        {
            AudioListener.volume = 1;  // Unmute all audio
        }
    }

    // Getter for isMutedGlobally
    public bool GetIsMutedGlobally()
    {
        return isMutedGlobally;
    }

    // Setter for isMutedGlobally
    public void SetIsMutedGlobally(bool value)
    {
        isMutedGlobally = value;
        AudioListener.volume = isMutedGlobally ? 0 : 1;
    }
}
