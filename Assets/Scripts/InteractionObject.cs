using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    public string infoMessage;

    public TMP_Text infoText;

    public enum InteractionType
    {
        Nothing,
        Pickup,
        Info,
        Dialogue
    }

    private DialogueManager dialogueManagerRef;

    [Header("Type of Interactable")]
    public InteractionType interType; // Creates a drop-down menu based on the InteractionType enum

    [Header("Dialogue Text")]
    [TextArea] public string[] sentences; // Creates a drop-down menu based on the InteractionType enum

    private void Awake()
    {
        dialogueManagerRef = GetComponent<DialogueManager>();
    }

    public void Interact()
    {
        switch(interType)
        {
            case InteractionType.Nothing:
                Nothing();
                break;

            case InteractionType.Pickup:
                Pickup();
                break;

            case InteractionType.Info:
                Info();
                break;

            case InteractionType.Dialogue:
                Dialogue();
                break;
        }
    }

    public void Nothing()
    {
        Debug.Log($"Interaction type not defined");
    }

    public void Pickup()
    {
        Debug.Log($"Picking up object: {gameObject.name}");
        gameObject.SetActive(false);
    }

    public void Info()
    {
        Debug.Log($"Display info about object: {gameObject.name}");
        infoText.text = infoMessage;
    }

    public void Dialogue()
    {
        dialogueManagerRef.DialogueSystem(sentences);
        Time.timeScale = 1f;
    }
}
