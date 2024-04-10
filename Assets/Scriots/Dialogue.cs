using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Vector3 dialogueOffset = new Vector3(0, 2, 0); // Adjust this value as needed

    private Transform npcTransform;
    private Canvas dialogueCanvas;
    private int index;
    private bool isTyping = false;


    private void Awake()
    {
        // Ensure the dialogue box is initially disabled to avoid showing up unwantedly
        gameObject.SetActive(false);
    }

    public bool IsTyping
{
    get { return isTyping; }
}

     private void Start()
    {
        dialogueCanvas = GetComponentInParent<Canvas>(); // Assuming this script is attached to the Canvas GameObject
        dialogueCanvas.enabled = false; // Hide the dialogue canvas initially
    }   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && npcTransform != null)
        {
            if (!isTyping)
            {
                NextLine();
            }
            else
            {
                // Complete the typing instantly
                StopAllCoroutines();
                textComponent.text = lines[index];
                isTyping = false;
            }
        }

       

        // Update the dialogue box's position if it's active and the NPC transform is set
        // if (gameObpublic void ActivateDialogue(Transform npcTransform)
    {
        this.npcTransform = npcTransform;
        index = 0; // Reset the index for the new dialogue
        dialogueCanvas.enabled = true; // Show the dialogue canvas
        StartDialogue();
    }
            // Position the dialogue box above the NPC with the given offset
            transform.position = npcTransform.position + dialogueOffset;
        }

       


    

    

    // public void ActivateDialogue(Transform npcTransform)
    // {
    //     // Ensure the dialogue box is active before starting the coroutine
    //     gameObject.SetActive(true);

    //     this.npcTransform = npcTransform;
    //     index = 0; // Reset index to show the first line
    //     StartDialogue();
    // }


            public void ActivateDialogue(Transform npcTransform)
{
    this.npcTransform = npcTransform;
    index = 0; // Reset the index for the new dialogue
    
    // Ensure gameObject is active before enabling the canvas and starting dialogue
    gameObject.SetActive(true);
    dialogueCanvas.enabled = true; // Show the dialogue canvas
    
    StartDialogue();
}


    void StartDialogue()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        isTyping = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty; // Clear the text for the next line
            isTyping = true;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // Hide the dialogue box after the last line
            textComponent.text = string.Empty; // Clear text for the next interaction
        }
    }

    void PositionDialogueBox(Vector3 npcPosition)
{
    Vector3 worldPosition = npcPosition + dialogueOffset; // Apply the offset in world space
    Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
    // dialogueRectTransform.position = screenPoint;
}

}