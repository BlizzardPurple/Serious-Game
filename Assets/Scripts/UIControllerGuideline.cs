// Inherits the UIController class
// For Displaying the Guideline canvas

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class UIControllerGuideline : UIController
    {
        private GameObject closeButton;
        public Text text1;
        public Text text2;
        NpcCharacteristics characteristics=null;
        bool allTasksDone = false;

        void Start()
        {
            base.Start();
            closeButton = GameObject.FindGameObjectWithTag("Close Button");
        }

        public void ShowCanvas(NpcCharacteristics nc)
        {
            characteristics = nc;
            text1.text = nc.text1;
            text2.text = nc.text2;
            base.ShowCanvas();
            EventSystem.current.SetSelectedGameObject(closeButton);
        }
        
        public void ShowCanvas(string text1, string text2)
        {
            this.text1.text = text1;
            this.text2.text = text2;
            
            base.ShowCanvas();
            EventSystem.current.SetSelectedGameObject(closeButton);
        }

        public void CloseBtnClicked()
        {
            HideCanvas();
            if(characteristics != null)
                characteristics.guidelineRead = true;
            else
                allTasksDone = true;
        }
    }
}