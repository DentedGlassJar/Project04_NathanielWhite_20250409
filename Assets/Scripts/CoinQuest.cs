using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinQuest : MonoBehaviour
{
    // Enum representing different game states
    public enum GameState
    {
        Before_State,   
        During_State,   
        After_State      
    }

    // Property to store the current game state, accessible publicly but modifiable only within this class
    public GameState currentState { get; private set; }

    public GameObject beforeObj;
    public GameObject duringObj;
    public GameObject afterObj;

    public PlayerInteraction playerInteractionRef;

    // Debugging variables to store the current and last game state as strings for easier debugging in the Inspector
    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

    private void Start()
    {
        // Set the initial state of the game to Main Menu when the game starts
        ChangeState(GameState.Before_State);
    }

    // Method to change the current game state
    public void ChangeState(GameState newState)
    {
        // Store the current state as the last state before changing it
        lastStateDebug = currentState.ToString();

        // Assign the new state to currentState
        currentState = newState;

        // Call a function to handle any specific actions triggered by the state change
        HandleStateChange(newState);

        // Store the new state in a string variable for debugging purposes
        currentStateDebug = currentState.ToString();
    }

    // Handles any specific actions that need to occur when switching to a new state
    private void HandleStateChange(GameState state)
    {
        if (currentState == GameState.Before_State)
        {
            beforeObj.SetActive(true);
        }
        else
        {
            beforeObj.SetActive(false);
        }

        if (currentState == GameState.During_State)
        {
            duringObj.SetActive(true);
        }
        else
        {
            duringObj.SetActive(false);
        }

        if (currentState == GameState.After_State)
        {
            afterObj.SetActive(true);
        }
        else
        {
            afterObj.SetActive(false);
        }

        switch (state)
        {
            case GameState.Before_State:
                Debug.Log("Switched to MainMenu State");
                break;

            case GameState.During_State:
                Debug.Log("Switched to Gameplay State");
                break;

            case GameState.After_State:
                Debug.Log("Switched to Paused State");
                break;
        }
    }
}
