// This script contains the logic for showing and hiding the canvas
// This script is used as parent class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] public Canvas canvas;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    protected void Start()
    {
        canvas.enabled = false;
        playerMovement = GameObject.FindGameObjectWithTag("Player")!=null?GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>():null;
        
    }

    public void ShowCanvas()
    {
        canvas.enabled = true;
        if(playerMovement != null)
        playerMovement.enabled = false;
    }

    public void HideCanvas()
    {
        canvas.enabled = false;
        if(playerMovement != null)
        playerMovement.enabled = true;
    }


    public void CloseBtnClicked()
    {
        HideCanvas();
    }
}