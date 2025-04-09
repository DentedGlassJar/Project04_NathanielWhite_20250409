using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static InputManager;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    Animator playerFloatDirection;

    public Vector2 moveDirection;
    private float moveSpeed = 5.0f;

    private float xFloat;
    private float yFloat;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        playerFloatDirection = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Actions.moveEvent += UpdateVector;
    }

    private void OnDisable()
    {
        Actions.moveEvent -= UpdateVector;
    }

    void HandlePlayerMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    // if the MoveEvent is enabled, it updates the moveVector value with the inputVector value
    void UpdateVector(Vector2 inputVector)
    {
        moveDirection = inputVector;
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
        DirectionAnimator();
    }

    private void DirectionAnimator()
    {
        xFloat = moveDirection.x;
        yFloat = moveDirection.y;

        playerFloatDirection.SetFloat("X", xFloat);
        playerFloatDirection.SetFloat("Y", yFloat);

    }
}
