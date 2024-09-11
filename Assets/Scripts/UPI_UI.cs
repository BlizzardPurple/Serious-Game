using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UPI_UI : MonoBehaviour
{
    [SerializeField] public GameObject DialogPanel;
    [SerializeField] public GameObject UPIPanel;
    [SerializeField] public TextMeshProUGUI DialogsPanelText;
    [SerializeField] public GameObject ScrollPanel;

    private string[] pin = {
         "_ _ _ _",
         "* _ _ _",
         "* * _ _",
         "* * * _",
         "* * * *", //NU
    };

    private string[] dialog = {
        "What is going on? My UPI pin is auto submitting without any prompt from me. Let me try again.",
        "This is clearly a bug that I need to report.",
        "I've reported the bug. Let me pay you through cash for now.",
    };

    private int curr_digits = 0;
    private int wrong_cnt = 0;
    private bool can_type = true;
    private string wrongUpiStr = "Wrong PIN detected\nPlease try after some time";
    [SerializeField] public TextMeshProUGUI upi_pin;
    [SerializeField] public TextMeshProUGUI wrongupi3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) ||
            Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Alpha4) ||
            Input.GetKeyDown(KeyCode.Alpha5) ||
            Input.GetKeyDown(KeyCode.Alpha6) ||
            Input.GetKeyDown(KeyCode.Alpha7) ||
            Input.GetKeyDown(KeyCode.Alpha8) ||
            Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (StaticVariables_Inside_Market.isPhoneOpen)
            {
                Debug.Log("isPhoneOpen is true and num increased");
                inc();
            }
            
        }
    }

    public void inc(){
        curr_digits = (curr_digits + 1);
        if(curr_digits == 4){
            curr_digits = 0;
            wrong_cnt++;
        }
        if(can_type) upi_pin.text = pin[curr_digits];
        if(wrong_cnt == 1){
            DialogPanel.SetActive(true);
            DialogsPanelText.text = dialog[0];
        }
        if(wrong_cnt == 2){
            can_type = false;
            wrongupi3.text = wrongUpiStr;
            DialogsPanelText.text = dialog[1];
            // next dialog
        }  
    }

    public void dec(){
        if(curr_digits != 0){
            curr_digits--;
            if(can_type) upi_pin.text = pin[curr_digits];
        }
    }

    public void reportbug(){
        DialogsPanelText.text = dialog[2];
        Invoke("f", 2f);
    }
     
    private void f()
    {
        ScrollPanel.SetActive(true);
        UPIPanel.SetActive(false);
        DialogPanel.SetActive(false);
    }

}
