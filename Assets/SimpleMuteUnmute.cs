using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMuteUnmute : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isMuted = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        //if(false)
        {

            isMuted = !isMuted;
            if (isMuted)
            {
                AudioListener.volume = 0;
                Debug.Log("M key pressed, muted now");
            }
            else
            {
                AudioListener.volume = 100;
                Debug.Log("M key pressed, not muted anymore");
            }
        }
    }
}
