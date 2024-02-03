// This script is for managing key 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public GameObject chestWithKey;
    private Transform player;
    [SerializeField] private float interactionDistance = 1f;

    [SerializeField] private Image keyIconStatusBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        keyIconStatusBar.enabled = false;
    }

    private void Update()
    {
        Pickup();
    }

    private void Pickup()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= interactionDistance)
        {
            ChestController chestController = chestWithKey.GetComponent<ChestController>();
            if (chestController != null)
            {
                Debug.Log("key Picked");
                keyIconStatusBar.enabled = true;
                chestController.hasKey = true;
            }

            Destroy(gameObject);
        }
    }
}
