using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class InputReader : MonoBehaviour
{
    private InputMaster playerControls;
    
    [SerializeField] private Vector2 move = Vector2.zero;
    [SerializeField] private bool jumpPressed = false;
    [SerializeField] private bool punchPressed = false;

    private Vector2 downBackPos;
    private Vector2 downPos;
    private Vector2 downForwardPos;
    private Vector2 backPos;
    private Vector2 neutralPos;
    private Vector2 forwardPos;
    private Vector2 upBackPos;
    private Vector2 upPos;
    private Vector2 upForwardPos;

    private void DefinePositions()
    {
        float regSqr = Mathf.Sqrt(2f) / 2f;
        float stdPoint = 1f;
        
        downBackPos = new Vector2(-regSqr, -regSqr);
        downPos = new Vector2(0f, -1f);
        downForwardPos = new Vector2(regSqr, -regSqr);
        backPos = new Vector2(-1f, 0f);
        neutralPos = new Vector2(0f, 0f);
        forwardPos = new Vector2(1f, 0f);
        upBackPos = new Vector2(-regSqr, regSqr);
        upPos = new Vector2(0f, 1f);
        upForwardPos = new Vector2(regSqr, regSqr);
    }
    
    private void Awake()
    {
        DefinePositions();
        
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

        if (currentInput != 0)
        {
            Debug.Log(inputRecorded);
        }
        else
        {
            Debug.Log("INPUT ERROR OCCURRED. 0 Detected");
        }
        
    }

    private int InterpretInput()
    {
        int currentInput = 5;
        
        Vector2 currentClosest = neutralPos - move;

        if (currentClosest.magnitude > (downBackPos - move).magnitude)
        {
            currentClosest = downBackPos - move;
            currentInput = 1;
        }

        if (currentClosest.magnitude > (downPos - move).magnitude)
        {
            currentClosest = downPos - move;
            currentInput = 2;
        }

        if (currentClosest.magnitude > (downForwardPos - move).magnitude)
        {
            currentClosest = downForwardPos - move;
            currentInput = 3;
        }
        
        if (currentClosest.magnitude > (backPos - move).magnitude)
        {
            currentClosest = backPos - move;
            currentInput = 4;
        }
        
        if (currentClosest.magnitude > (neutralPos - move).magnitude)
        {
            currentClosest = neutralPos - move;
            currentInput = 5;
        }
        
        if (currentClosest.magnitude > (forwardPos - move).magnitude)
        {
            currentClosest = forwardPos - move;
            currentInput = 6;
        }
        
        if (currentClosest.magnitude > (upBackPos - move).magnitude)
        {
            currentClosest = upBackPos - move;
            currentInput = 7;
        }
        
        if (currentClosest.magnitude > (upPos - move).magnitude)
        {
            currentClosest = upPos - move;
            currentInput = 8;
        }
        
        if (currentClosest.magnitude > (upForwardPos - move).magnitude)
        {
            currentClosest = upForwardPos - move;
            currentInput = 9;
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