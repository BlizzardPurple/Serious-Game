// This script manages the flow of dialogs

using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;


public class DialogueManager : MonoBehaviour
{
	public Image actorImage;
	public TextMeshProUGUI actorName;
	public TextMeshProUGUI messageText;
	public RectTransform backgroundBox;
	Rigidbody2D playerRigidbody;
	PlayerMovement playerMovement;


    Message[] currentMessages;
	Actor[] currentActors;
	NpcCharacteristics nc;
	int activeMessage=0;

	public bool isActive = false;
    [FormerlySerializedAs("controller")] public UIControllerGuideline controllerGuideline;

	// Displays the message
    public void OpenDialogue(Message[] messages, Actor[] actors, NpcCharacteristics npcC)
	{
		currentMessages = messages;
		currentActors = actors;
		nc = npcC;
		if(nc!=null && nc.npc2object == null)
			nc.remote.SetActive(true);
		activeMessage = 0;
		
		
		isActive = true;
		// playerRigidbody.bodyType = RigidbodyType2D.Static;
		if (playerMovement != null)
		{
			playerMovement.animator.SetBool("IsMoving", false);
			playerMovement.enabled = false;
		}

		Debug.Log("Started conversation! Loaded messages: " + messages.Length);
		DisplayMessage();
		backgroundBox.LeanScale(Vector3.one, 0.2f).setEaseInOutExpo();
	}

	void AnimateTextColor()
	{
		LeanTween.textAlpha(messageText.rectTransform, 0, 0);
		LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
	}

	void DisplayMessage()
	{
		Message messageToDisplay = currentMessages[activeMessage];
		string formattedMessage = ReplaceVariables(messageToDisplay.message);

		messageText.text = formattedMessage;

		Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        string formattedName = ReplaceVariables(actorToDisplay.name);
        actorName.text = formattedName;
		actorImage.sprite = actorToDisplay.sprite;
		AnimateTextColor(); //NOT WORKING CHECK
	}

	public void NextMessage()
	{
		activeMessage++;
		if (activeMessage >= currentMessages.Length)
		{
			Debug.Log("Ended conversation!");
			backgroundBox.LeanScale(Vector3.zero, 0.2f).setEaseInOutExpo();
			// playerRigidbody.bodyType = RigidbodyType2D.Kinematic;
			if (playerMovement != null)
			{
				playerMovement.animator.SetBool("IsMoving", true);
				playerMovement.enabled = true;
			}

			isActive = false;
			
			if (nc!=null && nc.taskDone)
			{
				controllerGuideline = FindObjectOfType<UIControllerGuideline>();
				controllerGuideline.ShowCanvas(nc);
			}
		}
		else
		{
			DisplayMessage();
		}
	}

	string ReplaceVariables(string message)
	{
        return message.Replace("{PlayerName}", ReadName.playerName);
    }

	void Start()
	{
		backgroundBox.transform.localScale = Vector3.zero;
		playerRigidbody = GameObject.FindGameObjectWithTag("Player")!=null?GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>():null;
		playerMovement = GameObject.FindGameObjectWithTag("Player")!=null?GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>():null;
		
	}


	/*void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isActive)
			NextMessage();
	}*/
}
