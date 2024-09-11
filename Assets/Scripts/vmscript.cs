using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

using TMPro;

public class vmscript : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI vmtext;
    [SerializeField] public GameObject DialogPanel;
    [SerializeField] public GameObject VMPanel;
    [SerializeField] public GameObject ScrollPanel;
    [SerializeField] public TextMeshProUGUI DialogsPanelText;
    [SerializeField] public Sprite brendanSprite;
    [SerializeField] public Sprite richLadySprite;
    [SerializeField] public Image spriteImage;
    [SerializeField] public GameObject trig;
    string brendantext = "This seems to be a focus issue, where the items are incrementing by 5 instead of 1. Let me fix this.";
    string girltext = "Thank you so much for the help!";
    private int currentItemNumber = 1; // Start with item number 1
    private bool problemfixed = false;
    private int increval = 5;
    public GuidelinesManagement guidelinesManagement;
    private bool sceenefinished = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (StaticVariables_Inside_Market.isVMPanelOpen == true)
            {
                //if (Input.GetKeyDown(KeyCode.Space)) return;
                nextItem();
            }
        }
    }

    void Start()
    {
        // Set the initial text
        vmtext.text = "Selected Item: " + currentItemNumber;
        trig.SetActive(false);
    }

    public void nextItem()
    {
        // Increase the current item number by 5
        currentItemNumber = (currentItemNumber + increval)%18;

        // Update the text
        vmtext.text = "Selected Item: " + currentItemNumber;

        if(true){
            DialogPanel.SetActive(false);
            Debug.Log("to see if this calls between fixing the problem" + currentItemNumber);
            
        }
        

        if(currentItemNumber == 11){
            if(!problemfixed){
                Debug.Log("We are showing Dialog");
                DialogPanel.SetActive(true);
                DialogsPanelText.text = brendantext;
                spriteImage.sprite = brendanSprite;
                currentItemNumber = 0;
                increval = 1;
                problemfixed = true;
            }           
        }

        if(currentItemNumber == 4){
            DialogPanel.SetActive(true);
            DialogsPanelText.text = girltext;
            spriteImage.sprite = richLadySprite;
            
            //await Task.Delay(2000);
            //VMPanel.SetActive(false);
            //await Task.Delay(2000);
            //DialogPanel.SetActive(false);
            
            //guidelinesManagement.vmfixed = false;
            deletePanels();
            trig.SetActive(true);
            sceenefinished = true;
        }
    }

    void deletePanels()
    {
        Invoke("deleteVM", 2f); // Calls DelayedMethod after 2 seconds
        Invoke("deleteDP", 4f);
        Invoke("ActiveSP", 2f);
        //Invoke("DeleteSP", 4f);
        //Invoke("Rescene", 0f);
    }

    void deleteDP(){
        if(true){
            DialogPanel.SetActive(false);
        }
        
    }

    void rescene(){

    }

    void ActiveSP(){
        ScrollPanel.SetActive(true);
    }

    public void DeleteSP(){
        ScrollPanel.SetActive(false);
    }

    void deleteVM(){
        VMPanel.SetActive(false);
        StaticVariables_Inside_Market.isVMPanelOpen = false;
    }
}
