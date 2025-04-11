using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    public string infoMessage;

    public TMP_Text infoText;

    public GameObject ChiselMark;
    public GameObject MarshMark;
    public GameObject BillMark;

    public PlayerInteraction playerRef;

    public enum InteractionType
    {
        Nothing,
        Coin,
        Gem,
        Marshmallow,
        Bill,
        Chisel,
        Hamburger,
        Info,
        Dialogue,
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

    private void Update()
    {
        if (playerRef == null)
        {
            playerRef = GameObject.Find("PlayerController").GetComponent<PlayerInteraction>();
        }
    }

    public void Interact()
    {
        switch (interType)
        {
            case InteractionType.Nothing:
                Nothing();
                break;

            case InteractionType.Coin:
                Coin();
                break;

            case InteractionType.Gem:
                Gem();
                break;

            case InteractionType.Marshmallow:
                Marshmallow();
                break;

            case InteractionType.Bill:
                Bill();
                break;

            case InteractionType.Chisel:
                Chisel();
                break;

            case InteractionType.Hamburger:
                Hamburger();
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
        //Debug.Log($"Interaction type not defined");
    }

    public void Coin()
    {
        playerRef.coinCount++;
        gameObject.SetActive(false);
    }

    public void Gem()
    {
        playerRef.gemCount++;
        gameObject.SetActive(false);
    }

    public void Marshmallow()
    {
        playerRef.marshmallowCollected = true;
        MarshMark.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Bill()
    {
        playerRef.billCollected = true;
        BillMark.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Chisel()
    {
        playerRef.chiselCollected = true;
        ChiselMark.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Hamburger()
    {
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
        Time.timeScale = 0f;
    }
}