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
    [SerializeField] public TextMeshProUGUI DialogsPanelText;
    [SerializeField] public Sprite brendanSprite;
    [SerializeField] public Sprite richLadySprite;
    [SerializeField] public Image spriteImage;
    string brendantext = "This seems to be a focus issue, where the items are incrementing by 5 instead of 1. Let me fix this.";
    string girltext = "Thank you so much for the help!";
    private int currentItemNumber = 1; // Start with item number 1
    private bool problemfixed = false;
    private int increval = 5;

    void Start()
    {
        // Set the initial text
        vmtext.text = "Selected Item: " + currentItemNumber;
    }

    public void nextItem()
    {
        // Increase the current item number by 5
        currentItemNumber = (currentItemNumber + increval)%18;

        // Update the text
        vmtext.text = "Selected Item: " + currentItemNumber;

        DialogPanel.SetActive(false);

        if(currentItemNumber == 11){
            if(!problemfixed){
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
            deletePanels();
        }
    }

    void deletePanels()
    {
        Invoke("deleteVM", 2f); // Calls DelayedMethod after 2 seconds
        Invoke("deleteDP", 4f);
    }

    void deleteDP(){
        DialogPanel.SetActive(false);
    }

    void deleteVM(){
        VMPanel.SetActive(false);
    }
}
