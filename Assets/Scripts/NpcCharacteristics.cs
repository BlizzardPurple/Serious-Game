// This script is used to manage npc characters

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcCharacteristics : MonoBehaviour
{
    public GameObject npc2object;
    public GameObject remote;
    
    
    private Transform player;
    [SerializeField] private float interactionDistance = 2;
    private DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public bool taskDone = false;
    public string text1;
    public string text2;
    public bool guidelineRead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueTrigger = GetComponent<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        if(npc2object != null)
            npc2object.SetActive(false);
        if(remote != null)
            remote.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // For player's interaction with npc 
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= interactionDistance && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueManager.isActive == false)
            {
                dialogueTrigger.StartDialog();
            }
            else
            {
                dialogueManager.NextMessage();
            }
        }
        
        // Grandpa (2nd npc) will be visible only when 1st task is complete
        if(guidelineRead && npc2object != null)
            npc2object.SetActive(true);
        if(guidelineRead && npc2object == null)
            remote.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Triggered Collider");
        // if (other.gameObject.tag == "Player")
        // {
        //     // GetComponent<DialogueTrigger>().StartDialog();
        // }

    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("Triggered Collider Stay");
        // if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        // {
        //     GetComponent<DialogueTrigger>().StartDialog();
        // }

    }
}
