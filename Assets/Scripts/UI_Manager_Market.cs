using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton pattern

    public GameObject UIPanel;
    public GameObject DialogPanel;
    public GameObject ScrollPanel;
    //public TMP_Text grandmaMessageText;

    //UI Phone
    public Image grandmaImage;
    public Image PhoneHomeScreen;
    public Image TranscriptApp;
    public Image WhatsappApp;
    public Image AssisstantApp;
    private bool inAssisstant = false;
    private bool assisstantSpoken = false;

    //dialog
    [SerializeField] public TextMeshProUGUI DialogsPanelText;
    private string[] messages = {
         "",
         "Oh! That's something new. Grandma's sent me a message! I should check it", //Home Screen,
         "The car is honking too much, I can't hear anything, maybe the assisstant will help", //WhatsApp,
         "I can't hear the recording my grandma just sent me. Can you help", //To Voice assistant,
         "There exists a feature on your mobile which provides transcipts to all pre-recorded voice notes.", //Voice Assitant Reply,
         "Finally! Now I can view grandma's message, it's an updated grocery list",
         "Yes, Transcript App will help provide captions for Grandma's message",
         "You have finished the level that corresponds to the WCAG Guideline 1.2.1. The intent of this success criterion is to make information conveyed by pre-recorded audio only and pre-recorded video only content available to all users" //Final
    };
    [SerializeField] public Image spriteImage;
    [SerializeField] public Sprite spriteOne;
    [SerializeField] public Sprite spriteTwo;
    private bool isUsingFirstSprite = true; //first is brendan, second is ai
    private bool end = false;

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
        //isUsingFirstSprite = true;
        //ChangeSprite();
        if(end){
            DialogPanel.SetActive(false);
            UIPanel.SetActive(false);
            ScrollPanel.SetActive(true);
            return;
        }
        PhoneHomeScreen.gameObject.SetActive(true);
        TranscriptApp.gameObject.SetActive(false);
        AssisstantApp.gameObject.SetActive(false);
        WhatsappApp.gameObject.SetActive(false);

        // SetMessageText(1);
    }

    public void ShowWhatsapp(){
        PhoneHomeScreen.gameObject.SetActive(false);
        TranscriptApp.gameObject.SetActive(false);
        AssisstantApp.gameObject.SetActive(false);
        WhatsappApp.gameObject.SetActive(true);
        SetMessageText(2);
    }

    public void ShowTranscript(){
        
        PhoneHomeScreen.gameObject.SetActive(false);
        TranscriptApp.gameObject.SetActive(true);
        AssisstantApp.gameObject.SetActive(false);
        WhatsappApp.gameObject.SetActive(false);
        SetMessageText(5);
        end = true;
    }

    public void ShowAssisstant(){
        isUsingFirstSprite = false;
        ChangeSprite();
        inAssisstant = true;

        PhoneHomeScreen.gameObject.SetActive(false);
        TranscriptApp.gameObject.SetActive(false);
        AssisstantApp.gameObject.SetActive(true);
        WhatsappApp.gameObject.SetActive(false);
        SetMessageText(3);
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

    public void ShowDialogPanel(){
        DialogPanel.SetActive(true);
        SetMessageText(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(inAssisstant){
                SetMessageText(4);
                isUsingFirstSprite = true;
                ChangeSprite();
                assisstantSpoken = true;
                inAssisstant = false;
            }
            else if(assisstantSpoken){
                isUsingFirstSprite = false;
                ChangeSprite();
                SetMessageText(6);
                assisstantSpoken = false;
            }
        }
    }

    public void SetMessageText(int index)
    {
        // Assuming you have a reference to the TMP_Text component
        // Replace 'yourTmpTextObject' with the actual name of your TMP_Text object
        DialogsPanelText.text = messages[index];
    }

    public void ChangeSprite()
    {
        if (isUsingFirstSprite)
        {
            spriteImage.sprite = spriteTwo; // ai
        }
        else
        {
            spriteImage.sprite = spriteOne; // brendan
        }
        
        // Toggle the flag
        //isUsingFirstSprite = !isUsingFirstSprite;
    }

    public void HideGrandmaMessage()
    {
        // Deactivate the UI elements to hide the message
        //grandmaImage.enabled = false;
        UIPanel.SetActive(false);
        DialogPanel.SetActive(false);
    }

    // Add methods for handling UI button clicks (e.g., answering the phone)
}