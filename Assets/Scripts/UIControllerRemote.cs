// Inherits the UIController class
// For Displaying the remote canvas

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class UIControllerRemote:UIController
    {
        //select button with tag "Power Button"
        private GameObject closeButton;

        void Start()
        {
            base.Start();
            closeButton = GameObject.FindGameObjectWithTag("Close Remote Button"); 
        }

        public void ShowCanvas()
        {
            base.ShowCanvas();
            EventSystem.current.SetSelectedGameObject(closeButton);
        }
    }
}