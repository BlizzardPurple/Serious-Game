// This script is used to navigate the excel in third task using keyboard

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExcelKeyboardNavigation : MonoBehaviour
{
    [SerializeField] Actor[] actors;
    [SerializeField] Message[] messages;
    [SerializeField]
    DialogueManager dialogueManager;
    [SerializeField] AudioSource audioSource;

    private bool firstClick;

    // Start is called before the first frame update
    void Start()
    {
        firstClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        // for displaying mouse not working dialog
        if (Input.mousePresent && !firstClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstClick = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
                if (dialogueManager.isActive == false)
                {
                    dialogueManager.OpenDialogue(messages, actors, null);
                }
            }
        }
        
        if (dialogueManager.isActive == true && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.NextMessage();
        }

        GameObject currentPanel = GetActivePanel();
        if (currentPanel != null)
        {
            //Shift-Tab Reverse 
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
            {
                if (EventSystem.current.currentSelectedGameObject == null ||
                    !IsChildOfCurrentPanel(EventSystem.current.currentSelectedGameObject, currentPanel))
                {
                    // If no UI element is selected or the selected element is not in the current panel, select the first button in the current panel.
                    SelectFirstButton(currentPanel);
                }

                {
                    Selectable previous =
                        GetPreviousSelectableInPanel(EventSystem.current.currentSelectedGameObject, currentPanel);
                    if (previous != null)
                    {
                        previous.Select();
                    }
                }
            }
            
            // else  if (Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.Tab))
            // {
            //     Debug.Log("Shift-Tab Right");
            //     if (EventSystem.current.currentSelectedGameObject == null ||
            //         !IsChildOfCurrentPanel(EventSystem.current.currentSelectedGameObject, currentPanel))
            //     {
            //         // If no UI element is selected or the selected element is not in the current panel, select the first button in the current panel.
            //         SelectFirstButton(currentPanel);
            //     }
            //
            //     {
            //         Selectable previous =
            //             GetPreviousSelectableInPanel(EventSystem.current.currentSelectedGameObject, currentPanel);
            //         if (previous != null)
            //         {
            //             Debug.Log("Previous");
            //             previous.Select();
            //         }
            //     }
            // }


            
            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (EventSystem.current.currentSelectedGameObject == null ||
                    !IsChildOfCurrentPanel(EventSystem.current.currentSelectedGameObject, currentPanel))
                {
                    // If no UI element is selected or the selected element is not in the current panel, select the first button in the current panel.
                    SelectFirstButton(currentPanel);
                }


                // Tab key pressed, navigate to the next selectable UI element in the current panel.
                
                    Selectable next =
                        GetNextSelectableInPanel(EventSystem.current.currentSelectedGameObject, currentPanel);
                    if (next != null)
                    {
                        next.Select();
                    }
            }
            
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                // Enter key pressed, trigger the click action on the currently selected button in the current panel.
                ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject,
                    new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
            }
        }
    }

    private GameObject GetActivePanel()
    {
        // Find the currently active panel (the one that is set visible).
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                return child.gameObject;
            }
        }

        return null;
    }

    private bool IsChildOfCurrentPanel(GameObject obj, GameObject currentPanel)
    {
        // Check if the given GameObject is a child of the current panel.
        return obj.transform.IsChildOf(currentPanel.transform);
    }

    private void SelectFirstButton(GameObject panel)
    {
        // Find the first selectable UI element (e.g., the first button) in the current panel and select it.
        Selectable firstSelectable = panel.GetComponentInChildren<Selectable>();
        if (firstSelectable != null)
        {
            firstSelectable.Select();
        }
    }

    private Selectable GetNextSelectableInPanel(GameObject currentSelected, GameObject panel)
    {
        // Find the next selectable UI element in the current panel based on the current selection.
        Selectable[] selectables = panel.GetComponentsInChildren<Selectable>();
        for (int i = 0; i < selectables.Length; i++)
        {
            if (selectables[i].gameObject == currentSelected)
            {
                // Return the next selectable (looping back to the first if at the end).
                return selectables[(i + 1) % selectables.Length];
            }
        }

        return null;
    }

    private Selectable GetPreviousSelectableInPanel(GameObject currentSelected, GameObject panel)
    {
        // Find the previous selectable UI element in the current panel based on the current selection.
        Selectable[] selectables = panel.GetComponentsInChildren<Selectable>();
        for (int i = 0; i < selectables.Length; i++)
        {
            if (selectables[i].gameObject == currentSelected)
            {
                // Return the previous selectable (looping back to the last if at the start).
                return selectables[(i - 1 + selectables.Length) % selectables.Length];
            }
        }

        return null;
    }
}