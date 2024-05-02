using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject flourObject;

    [SerializeField]
    private GameObject chipsObject;

    [SerializeField]
    private GameObject appleObject;

    [SerializeField] public GameObject DialogPanel;
    [SerializeField] public GameObject VMPanel;
    [SerializeField] public TextMeshProUGUI DialogsPanelText;
    [SerializeField] private Text objectText;
    [SerializeField] public Sprite brendanSprite;
    [SerializeField] public Sprite richLadySprite;
    [SerializeField] public Image spriteImage;

    private int objects=0;
    private bool brenDan = true;
    private int msgIndex = 1;

    private bool fixVM = true;


    void Start(){

          // Accessing Transform component
        //DialogPanel = GetComponent<GameObject>();

        // Accessing Rigidbody component
        //VMPanel = GetComponent<GameObject>();

       /* chipsObject=GetComponent<GameObject>();

        flourObject=GetComponent<GameObject>();

        appleObject=GetComponent<GameObject>();
        // Accessing Renderer component
        DialogsPanelText = GetComponent<TextMeshProUGUI>();

        // Accessing AudioSource component
        objectText = GetComponent<Text>();
        
        // Accessing custom scripts attached to the GameObject
        brendanSprite= GetComponent<Sprite>();

        richLadySprite=GetComponent<Sprite>();

        spriteImage=GetComponent<Image>();*/
        
        chipsObject.SetActive(false);
        appleObject.SetActive(false);
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(brenDan){
                spriteImage.sprite = brendanSprite;
                brenDan = !brenDan;
            }
            else if(!brenDan){
                //rich lady sprite
                spriteImage.sprite = richLadySprite;
                brenDan = !brenDan;
            }

            if(msgIndex == 4){
                // fix or check
            }
            msgIndex++;

            if(msgIndex <= 4) SetMessageText(msgIndex);
            else{
                DialogPanel.SetActive(false);
                if(fixVM){
                    VMPanel.SetActive(true);
                    fixVM = false;
                }
            }
        }
    }

    private string[] messages = {
         "",
         "Hey, this vending machine is not working, can you help?",
         "Sure, what's the problem?",
         "I am trying to purchase Item 4. When I press the Next button, the selector is moving from item 1 to item 6, instead of sequentially.",
         "Okay. Let me see how I can fix this.",
         "Finally! Now I can select the item I want! Thank you so much!",
    };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (true)
        {
            Debug.Log("Player reached the checkpoint!");

            // Call the appropriate function based on the objectName
            if (other.gameObject.CompareTag("flour"))
            {
                Destroy(other.gameObject);
                appleObject.SetActive(true);
                objects++;
                objectText.text= "Objects: "+objects;
            }
            else if (other.gameObject.CompareTag("chips"))
            {
                Destroy(other.gameObject);
                objects++;
                objectText.text= "Objects: "+objects;
                //call dialog canvas
                dialogCanvasEnable();
            }
            else if (other.gameObject.CompareTag("apple"))
            {
                Destroy(other.gameObject);
                chipsObject.SetActive(true);
                objects++;
                objectText.text= "Objects: "+objects;
            }
        }
    }

     public void SetMessageText(int index)
    {
        DialogsPanelText.text = messages[index];
    }

    void dialogCanvasEnable(){
        DialogPanel.SetActive(true);
        SetMessageText(1);
    }


}
