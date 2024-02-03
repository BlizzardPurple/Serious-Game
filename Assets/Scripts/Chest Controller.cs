// This script contains the logic to handle the chest
// When the chest is toggle to open the image canvas will be set active

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] Actor[] actors;
    [SerializeField] Message[] messages;
    [SerializeField]
    DialogueManager dialogueManager;
    private float interactionDistance = 2f; // Distance at which the player can interact with the chest.
    public Sprite openChestSprite;
    public Sprite closedChestSprite;

    public bool isOpen = false;
    public bool hasKey;
    private Transform player;
    [SerializeField]private NpcCharacteristics nc;

    public RectTransform itemScreen; // Reference to the item screen.

    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        // messages[0].message.Replace("{PlayerName}", ReadName.playerName);
        spriteRenderer = GetComponent <SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject npcObject = GameObject.FindGameObjectWithTag("Grandma");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent <PlayerMovement>();

        nc = npcObject.GetComponent<NpcCharacteristics>();


        itemScreen.localScale = Vector3.zero; // Initialize item screen to be hidden.

        SetChestState(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= interactionDistance && hasKey && Input.GetKeyDown(KeyCode.Space))
        {
            nc.taskDone = true;
            ToggleChestState();
        }
        
        if(distanceToPlayer <= interactionDistance && !hasKey && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You need a key to open this chest");
            // dialog popup for trying to open chest without key
            if (dialogueManager.isActive == false)
            {
                dialogueManager.OpenDialogue(messages, actors, null);
            }
            else
            {
                dialogueManager.NextMessage();
            }




        }
    }

    private void ToggleChestState()
    {
        isOpen = !isOpen;
        SetChestState(isOpen);
    }

    private void SetChestState(bool open)
    {
        if (open)
        {
            spriteRenderer.sprite = openChestSprite;
            OpenImage(); // Call the OpenImage method to display the image canvas.
        }
        else
        {
            spriteRenderer.sprite = closedChestSprite;
            CloseImage(); // Call the CloseImage method to hide the image canvas.
        }
    }

    private void OpenImage()
    {
        itemScreen.LeanScale(Vector3.one, 0.2f).setEaseInOutExpo();
        playerMovement.enabled = false;
    }

    private void CloseImage()
    {
        itemScreen.LeanScale(Vector3.zero, 0.2f).setEaseInOutExpo();
        playerMovement.enabled = true;
    }
}
