// This script is to managing audio

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    [SerializeField]private Button muteButton;
    [SerializeField]private Image muteImage;
    [SerializeField] private Image unmuteImage;
    private bool isMuted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            toggleSound();
        }
    }

    public void toggleSound()
    {
        if (isMuted)
        {
            audioSource.mute = false;
            isMuted = false;
            muteButton.image.sprite = unmuteImage.sprite;
            EventSystem.current.SetSelectedGameObject(GameObject.FindWithTag("Player"));
        }
        else
        {
            audioSource.mute = true;
            isMuted = true;
            muteButton.image.sprite = muteImage.sprite;
            EventSystem.current.SetSelectedGameObject(GameObject.FindWithTag("Player"));

        }
    }
}
