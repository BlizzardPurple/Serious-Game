// This script is used for starting new game if the game is ended

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Button playAgainButton;
    
    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(playAgainButton.gameObject);
    }

    public void NewGameLoader()
    {
        SceneManager.LoadScene("Start Scene", LoadSceneMode.Single);
    }
}
