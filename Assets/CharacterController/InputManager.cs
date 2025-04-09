using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    private GameInput gameInput;

    // Start is called before the first frame update
    void Start()
    {
        gameInput = new GameInput();

        gameInput.Player.Enable();

        gameInput.Player.SetCallbacks(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
            Debug.Log("Receiving Move Input : " + context.ReadValue<Vector2>());
            Actions.moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public static class Actions
    {
        public static Action<Vector2> moveEvent; 
    }
}
