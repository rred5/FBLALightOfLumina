using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {
            // Increment the player's score
            GameManager.Instance.AddEssenceScore(1);
            
            // Deactivate the LumEss GameObject to make it disappear
            gameObject.SetActive(false);

            // Optionally, you could destroy the LumEss GameObject instead of deactivating it
            // Destroy(gameObject);
        }
    }
}

