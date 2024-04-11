using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public bool playerIsClose;

    // public TextMeshProUGUI contButton;



    private GameObject player;
    public GameObject indicator;
    public Transform indicatorTransform;

    void Start()
    {
        dialogueText.text = "";

         if (indicator != null)
            indicator.SetActive(false);
        if (indicatorTransform != null){
            indicatorTransform.localScale = new Vector3(Mathf.Abs(indicatorTransform.localScale.x), indicatorTransform.localScale.y, indicatorTransform.localScale.z);
        }
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerIsClose)
        {
            FlipTowardsPlayer();
            

            if(Input.GetKeyDown(KeyCode.E))
            {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            
            else if (dialogueText.text == dialogue[index])
            {
                // contButton.SetActive(true);
                NextLine();
            }

            }
        }
    
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    //gets rid of text after player moves away
    public void RemoveText()
{
    // Only try to change text if the dialogueText is not null
    if (dialogueText != null)
    {
        dialogueText.text = "";
    }
    index = 0;
    // Only deactivate if the dialoguePanel is not null
    if (dialoguePanel != null)
    {
        dialoguePanel.SetActive(false);
    }
}

    //adds the typing animation
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            // Debug.Log("close");
            if (indicator != null)
                indicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        playerIsClose = false;
        // Check if the indicator is not null before trying to set it inactive
        if (indicator != null && indicator.activeInHierarchy)
        {
            indicator.SetActive(false);
        }

        // Same for dialoguePanel
        if (dialoguePanel != null && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }
}
    void FlipTowardsPlayer()
    {
        bool playerIsOnLeft = player.transform.position.x < transform.position.x;
        Vector3 localScale = transform.localScale;
        localScale.x = playerIsOnLeft ? -Mathf.Abs(localScale.x) : Mathf.Abs(localScale.x);
        transform.localScale = localScale;

        // If the NPC flips, apply the opposite scaling to the indicator
        if (indicatorTransform != null)
            indicatorTransform.localScale = new Vector3(Mathf.Abs(indicatorTransform.localScale.x) * (playerIsOnLeft ? -1 : 1), indicatorTransform.localScale.y, indicatorTransform.localScale.z);
    }
}