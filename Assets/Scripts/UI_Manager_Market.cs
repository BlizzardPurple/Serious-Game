using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton pattern

    public GameObject UIPanel;
    //public TMP_Text grandmaMessageText;
    public Image grandmaImage;
    public Image PhoneHomeScreen;
    public Image TranscriptApp;
    public Image WhatsappApp;
    public Image AssisstantApp;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowHome(){
        //PhoneHomeScreen.SetActive(true);
        PhoneHomeScreen.gameObject.SetActive(true);
        TranscriptApp.gameObject.SetActive(false);
        AssisstantApp.gameObject.SetActive(false);
        WhatsappApp.gameObject.SetActive(false);
    }

    public void ShowWhatsapp(){
        PhoneHomeScreen.gameObject.SetActive(false);
        TranscriptApp.gameObject.SetActive(false);
        AssisstantApp.gameObject.SetActive(false);
        WhatsappApp.gameObject.SetActive(true);
    }

    public void ShowTranscript(){
        PhoneHomeScreen.gameObject.SetActive(false);
        TranscriptApp.gameObject.SetActive(true);
        AssisstantApp.gameObject.SetActive(false);
        WhatsappApp.gameObject.SetActive(false);
    }

    public void ShowAssisstant(){
        PhoneHomeScreen.gameObject.SetActive(false);
        TranscriptApp.gameObject.SetActive(false);
        AssisstantApp.gameObject.SetActive(true);
        WhatsappApp.gameObject.SetActive(false);
    }

    public void ShowPhonePanel()
    {
        // Activate the UI elements to display the message
        UIPanel.SetActive(true);
        //ShowHome();
        PhoneHomeScreen.gameObject.SetActive(true);
        //grandmaImage.SetActive(true);
        //grandmaImage.enabled = true;

        // You can customize the message based on your needs
        //grandmaMessageText.text = "Grandma is calling! Pick up the phone?";
    }

    public void HideGrandmaMessage()
    {
        // Deactivate the UI elements to hide the message
        //grandmaImage.enabled = false;
        //UIPanel.SetActive(false);
    }

    // Add methods for handling UI button clicks (e.g., answering the phone)
}