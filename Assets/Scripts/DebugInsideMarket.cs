using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Debugger : MonoBehaviour
{
    [SerializeField] public GameObject DialogPanel;
    [SerializeField] public GameObject upiPanel;
    [SerializeField] public GameObject chips_cashier;
    [SerializeField] public TextMeshProUGUI DialogsPanelText;
    [SerializeField] public Sprite brendanSprite;
    [SerializeField] public Sprite cashierSprite;
    [SerializeField] public Image spriteImage;

    private bool brenDan = true;
    private bool upiOpen = false;
    private int mi = 1;
    private bool enableupdate = false;



    private string[] messages = {
         "",
         "Hey, I'd like to pay for my items.",
         "Sure, your total is Rs. 249.",
         "Okay, let me pay through UPI.",
         "Sure, please scan the QR Code to pay.", 
         "Now I need to enter my pin.",
    };

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && mi<7)
        {
            if(brenDan){
                spriteImage.sprite = brendanSprite;
                brenDan = !brenDan;
            }
            else if(!brenDan){
                spriteImage.sprite = cashierSprite;
                brenDan = !brenDan;
            }
            mi++;
            //SetMessageText(mi);
            Debug.Log(mi);

            if(mi <= 5) {
                SetMessageText(mi);
            }
            else{
                DialogPanel.SetActive(false);
                if(!upiOpen){
                    upiPanel.SetActive(true);
                    upiOpen = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (true)
        {
            // Call the appropriate function based on the objectName
            if (other.gameObject.CompareTag("cashier"))
            {
                Debug.Log("Player reached the cashier!");
                dialogCanvasEnable();
                mi = 1;
                brenDan = true;
                enableupdate = true;
                spriteImage.sprite = cashierSprite;
            }
        }
    }

     public void SetMessageText(int index)
    {
        DialogsPanelText.text = messages[index];
    }

    void dialogCanvasEnable(){
        DialogPanel.SetActive(true);
        Debug.Log("Enabled");
        SetMessageText(1);
    }


}
