using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add logic to save the player's progress or perform other actions
            Debug.Log("Player reached the checkpoint!");
        }
    }
}
