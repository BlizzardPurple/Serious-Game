// This script is used to open and close the family image when chest is toggled

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenItem : MonoBehaviour
{
    public RectTransform itemScreen;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        itemScreen.localScale = Vector3.zero;
    }

    public void OpenImage()
    {
        itemScreen.LeanScale(Vector3.one, 0.2f).setEaseInOutExpo();
        playerMovement.enabled = false;
    }

    public void CloseImage()
    {
        itemScreen.LeanScale(Vector3.zero, 0.2f).setEaseInOutExpo();
        playerMovement.enabled = true;
    }
}
