// Inherits the UIController class
// For Displaying the hints canvas

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControllerControlsHint : UIController
{
    private GameObject closeButton;

    void Start()
    {
        base.Start();
        closeButton = GameObject.FindGameObjectWithTag("Close Button Controls Hint"); 
        ShowCanvas();
    }

    public void ShowCanvas()
    {
        base.ShowCanvas();
        EventSystem.current.SetSelectedGameObject(closeButton);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowCanvas();
        }
    }
}