// Displaying remote canvas

using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
    private UIControllerRemote controllerRemote;
    Rigidbody2D rb;
    Collider2D col;
    [SerializeField] private float interactionDistance = 2;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= interactionDistance && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            controllerRemote = FindObjectOfType<UIControllerRemote>();
            controllerRemote.ShowCanvas();
        }

    }
}
