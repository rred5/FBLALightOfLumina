using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject indicator; // Assign this in the Inspector
    public Dialogue dialogue; // Assign your Dialogue component in the Inspector
    private GameObject player; // To store a reference to the player GameObject
    private bool isPlayerInRange = false;

    private void Start()
    {
        if (indicator != null)
            indicator.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            FlipTowardsPlayer();
            
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.I)) // Assuming 'I' is your interact key
            {
                dialogue.ActivateDialogue(transform.position, transform); // Pass the NPC's position when activating the dialogue
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (indicator != null)
                indicator.SetActive(true);
            
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (indicator != null)
                indicator.SetActive(false);

            isPlayerInRange = false;
        }
    }

    void FlipTowardsPlayer()
    {
        bool playerIsOnLeft = player.transform.position.x < transform.position.x;
        Vector3 localScale = transform.localScale;
        localScale.x = playerIsOnLeft ? -Mathf.Abs(localScale.x) : Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }
}