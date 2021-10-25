using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputMaster playerControls;

    [SerializeField] private Vector2 move = Vector2.zero;
    [SerializeField] private bool jumpPressed = false;
    [SerializeField] private bool punchPressed = false;
    
    private void Awake()
    {
        playerControls = new InputMaster();
        playerControls.Player.Movement.performed += context => move = context.ReadValue<Vector2>();
        playerControls.Player.Movement.canceled += context => move = Vector2.zero;
        
        //playerControls.Player.Movement.performed += context => DisplayInput();
        //playerControls.Player.Movement.canceled += context => DisplayInput();

        playerControls.Player.Jump.started += context => JumpPressed();
        playerControls.Player.Punch.started += context => PunchPressed();
        playerControls.Player.Jump.canceled += context => JumpNoPressed();
        playerControls.Player.Punch.canceled += context => PunchNoPressed();
    }
    private void OnEnable()
    {
        playerControls.Player.Enable();
    }
    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    private void PunchPressed()
    {
        punchPressed = true;
        //Debug.Log("Punch Pressed");
    }

    private void PunchNoPressed()
    {
        punchPressed = false;
    }
    
    private void JumpPressed()
    {
        jumpPressed = true;
        //Debug.Log("Jump Pressed");
    }

    private void JumpNoPressed()
    {
        jumpPressed = false;
    }
    
    private void DisplayInput(int currentInput)
    {
        
        String inputRecorded = "" + currentInput;

        
        
        if (punchPressed)
        {
            inputRecorded += " P";
        }

        if (jumpPressed)
        {
            inputRecorded += " J";
        }

        if (currentInput != 99)
        {
            Debug.Log(inputRecorded);
        }
        
    }

    private int InterpretInput()
    {
        float xFloat = move.x;
        float yFloat = move.y;

        int currentInput = 99;
        
        int downBack = 1;
        int down = 2;
        int downForward = 3;
        int back = 4;
        int neutral = 5;
        int forward = 6;
        int upBack = 7;
        int up = 8;
        int upForward = 9;


        if ((xFloat < 0.2 && xFloat > -0.2) && (yFloat < 0.2 && yFloat > -0.2))
        {
            currentInput = neutral;
        }
        if (xFloat >= 0.2)
        {
            currentInput = forward;
        }

        return currentInput;
    }

    private void Update()
    {
        int currentInput;
        currentInput = InterpretInput();
        DisplayInput(currentInput);
    }
}