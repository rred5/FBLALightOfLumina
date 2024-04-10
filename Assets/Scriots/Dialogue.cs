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
    public RectTransform dialogueRectTransform;
    public Vector3 dialogueOffset;
    public float hideDistance = 5f; // Distance at which the dialogue box will be hidden

    private GameObject player;
    private Transform npcTransform; // NPC's Transform
    private int index;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(false); // Initially hide the dialogue box
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        // Check the distance between the player and the NPC
        if (npcTransform != null && player != null)
        {
            float distance = Vector3.Distance(player.transform.position, npcTransform.position);
            if (distance > hideDistance)
            {
                // Hide the dialogue box if the player is out of range
                gameObject.SetActive(false);
            }
        }
    }

    public void ActivateDialogue(Vector3 npcPosition, Transform npcTransform)
    {
        this.npcTransform = npcTransform; // Store the NPC's Transform
        textComponent.text = string.Empty;
        gameObject.SetActive(true); // Make sure the dialogue UI is enabled
        PositionDialogueBox(npcPosition + dialogueOffset);
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void PositionDialogueBox(Vector3 npcPosition)
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(npcPosition);
        dialogueRectTransform.position = screenPoint;
    }
}