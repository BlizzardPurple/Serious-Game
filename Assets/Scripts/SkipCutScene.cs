using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SkipCutScene : MonoBehaviour
{
    private PlayableDirector director;
    int timeStep=7;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // For skiping the current instance of the cutscene
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (director.time - (director.time % timeStep) + timeStep >= (float)director.duration)
                SceneManager.LoadScene("HOME", LoadSceneMode.Single);
            else
            {
                director.time = director.time - (director.time % timeStep) + timeStep;
                director.Evaluate();
            }
            
        }

        // For going to previous instance of the cutscene
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(director.time - (director.time % timeStep) - timeStep <= 7f)
                director.time = 0f;
            else
                director.time = director.time - (director.time % timeStep) - timeStep; 
            director.Evaluate();
        }
    }
}
