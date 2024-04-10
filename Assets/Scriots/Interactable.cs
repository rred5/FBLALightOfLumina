using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange; // To check if the player is within the interaction range
    public KeyCode interactKey; // The key to press to interact
    public UnityEvent interactAction; // The event to trigger when interacting

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            interactAction.Invoke(); // Invoke the interaction event
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
