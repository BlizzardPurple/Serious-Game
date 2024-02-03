// This script checks for the entered data in cells of excel and displays green color if data is correctly entered

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ValidateDataCell : MonoBehaviour
{
    [SerializeField] String CellKey;
    [SerializeField] GameObject Cell;
    [SerializeField] Image CellBackground;
    [SerializeField] TMP_InputField CellText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("CellText.text: " + CellText.text + " CellKey: " + CellKey);
        int CellTextInt = int.Parse(CellText.text);
        
        if (CellKey == "Bill Amt" && CellTextInt == 3500)
        {
            // Debug.Log("Bill Amt is 3500");
            // Debug.Log(CellTextInt);
            CellBackground.color = new Color(0.38f, 1f, 0.7f);
        }
        else if(CellKey == "Bill Amt")
        {
            CellBackground.color = new Color(1f, 0.68f, 0.68f);
        }
        
        if (CellKey == "Total Bill Amt" && CellTextInt == 16100)
        {
            // Debug.Log("Total Bill Amt is 16100");
            // Debug.Log(CellTextInt);
            CellBackground.color = new Color(0.38f, 1f, 0.7f);
        }
        else if(CellKey == "Total Bill Amt")
        {
            CellBackground.color = new Color(1f, 0.68f, 0.68f);
        }
        
        if (CellKey == "Total Balance" && CellTextInt == 2400)
        {
            // Debug.Log("Total Balance is 3500");
            // Debug.Log(CellTextInt);
            CellBackground.color = new Color(0.38f, 1f, 0.7f);
        }
        else if(CellKey == "Total Balance")
        {
            CellBackground.color = new Color(1f, 0.68f, 0.68f);
        }
        
    }
}
