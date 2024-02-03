// Displaying text on remote canvas

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoteCanvasHandler : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI resultText;
    [SerializeField]private NpcCharacteristics nc;
    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "Press Button";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NonCaptionButtonClicked()
    {
        resultText.text = "No Use";
    }
    
    public void CaptionButtonClicked()
    {
        resultText.text = "Aah Caption, it can be useful";
        nc.taskDone = true;
    }
}
