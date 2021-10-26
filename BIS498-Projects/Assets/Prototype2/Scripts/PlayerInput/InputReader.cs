using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputMaster playerControls;


    private DefinitionArea downBackArea;
    private DefinitionArea downArea;
    private DefinitionArea downForwardArea;
    private DefinitionArea backArea;
    private DefinitionArea neutralArea;
    private DefinitionArea forwardArea;
    private DefinitionArea upBackArea;
    private DefinitionArea upArea;
    private DefinitionArea upForwardArea;
    

    [SerializeField] private Vector2 move = Vector2.zero;
    [SerializeField] private bool jumpPressed = false;
    [SerializeField] private bool punchPressed = false;
    
    
    struct DefinitionArea
    {
        public Vector2 point1;
        public Vector2 point2;
        public Vector2 point3;
        public Vector2 point4;
        public Vector2[] vectorArray;
    }

    private void DefineAreas()
    {
        float unitSqr = (Mathf.Sqrt(3f) / 2f);
        float smallSqr = unitSqr / 5f;
        float regPoint = 0.5f;
        float littlePoint = regPoint / 5f;

        downBackArea.vectorArray = new Vector2[4];
        downBackArea.vectorArray[0] = new Vector2(-unitSqr, -regPoint);
        downBackArea.vectorArray[1] = new Vector2(-regPoint, -unitSqr);
        downBackArea.vectorArray[2] = new Vector2(-smallSqr, -littlePoint);
        downBackArea.vectorArray[3] = new Vector2(-littlePoint, -smallSqr);
        
        downArea.vectorArray = new Vector2[4];
        downArea.vectorArray[0] = new Vector2(-regPoint, -unitSqr);
        downArea.vectorArray[1] = new Vector2(regPoint, -unitSqr);
        downArea.vectorArray[2] = new Vector2(-littlePoint, -smallSqr);
        downArea.vectorArray[3] = new Vector2(littlePoint, -smallSqr);
        
        downForwardArea.vectorArray = new Vector2[4];
        downForwardArea.vectorArray[0] = new Vector2(regPoint, -unitSqr);
        downForwardArea.vectorArray[1] = new Vector2(unitSqr, -regPoint);
        downForwardArea.vectorArray[2] = new Vector2(littlePoint, -smallSqr);
        downForwardArea.vectorArray[3] = new Vector2(smallSqr, -littlePoint);
        
        backArea.vectorArray = new Vector2[4];
        backArea.vectorArray[0] = new Vector2(-unitSqr, regPoint);
        backArea.vectorArray[1] = new Vector2(-unitSqr, -regPoint);
        backArea.vectorArray[2] = new Vector2(-smallSqr, littlePoint);
        backArea.vectorArray[3] = new Vector2(-smallSqr, -littlePoint);
        
        /*neutralArea.point1 = new Vector2();
        neutralArea.point2 = new Vector2();
        neutralArea.point3 = new Vector2();
        neutralArea.point4 = new Vector2();*/
        
        forwardArea.vectorArray = new Vector2[4];
        forwardArea.vectorArray[0] = new Vector2(unitSqr, regPoint);
        forwardArea.vectorArray[1] = new Vector2(unitSqr, -regPoint);
        forwardArea.vectorArray[2] = new Vector2(smallSqr, littlePoint);
        forwardArea.vectorArray[3] = new Vector2(smallSqr, -littlePoint);
        
        upBackArea.vectorArray = new Vector2[4];
        upBackArea.vectorArray[0] = new Vector2(-unitSqr, regPoint);
        upBackArea.vectorArray[1] = new Vector2(-regPoint, unitSqr);
        upBackArea.vectorArray[2] = new Vector2(-smallSqr, littlePoint);
        upBackArea.vectorArray[3] = new Vector2(-littlePoint, smallSqr);
        
        upArea.vectorArray = new Vector2[4];
        upArea.vectorArray[0] = new Vector2(-regPoint, unitSqr);
        upArea.vectorArray[1] = new Vector2(regPoint, unitSqr);
        upArea.vectorArray[2] = new Vector2(-littlePoint, smallSqr);
        upArea.vectorArray[3] = new Vector2(littlePoint, smallSqr);
        
        upForwardArea.vectorArray = new Vector2[4];
        upForwardArea.vectorArray[0] = new Vector2(regPoint, unitSqr);
        upForwardArea.vectorArray[1] = new Vector2(unitSqr, regPoint);
        upForwardArea.vectorArray[2] = new Vector2(littlePoint, smallSqr);
        upForwardArea.vectorArray[3] = new Vector2(smallSqr, littlePoint);
    }
    
    private void Awake()
    {
        DefineAreas();
        
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
    
    
    
    public static bool IsPointInPolygon4(Vector2[] polygon, Vector2 testPoint)
    {
        bool result = false;
        int j = polygon.Count() - 1;
        for (int i = 0; i < polygon.Count(); i++)
        {
            if (polygon[i].y < testPoint.y && polygon[j].y >= testPoint.y || polygon[j].y < testPoint.y && polygon[i].y >= testPoint.y)
            {
                if (polygon[i].x + (testPoint.y - polygon[i].y) / (polygon[j].y - polygon[i].y) * (polygon[j].x - polygon[i].x) < testPoint.x)
                {
                    result = !result;
                }
            }
            j = i;
        }
        return result;
    }
    

    bool CheckInArea(DefinitionArea currArea)
    {
        float xFloat = move.x;
        float yFloat = move.y;
        
        if (xFloat >= currArea.point1.x)
        {
            return true;
        }

        return false;
    }

    private int InterpretInput()
    {
        float xFloat = move.x;
        float yFloat = move.y;

        int currentInput = 0;
        
        /*bool downBack = ((xFloat >= -0.9 && xFloat <= -0.1) && (yFloat <= -0.1 && yFloat >= -0.9));
        bool down = ((xFloat >= -0.1 && xFloat <= 0.1) && (yFloat <= -0.9));
        bool downForward = (xFloat >= 0.1 && xFloat <= 0.9) && (yFloat >= -0.9 && yFloat <= -0.1);
        bool back = ((xFloat <= -0.9) && (yFloat >= -0.1 && yFloat <= 0.1));
        bool neutral = ((xFloat >= -0.2 && xFloat <= 0.2) && (yFloat >= -0.2 && yFloat <= 0.2));
        bool forward = ((xFloat >= 0.9) && (yFloat >= -0.1 && yFloat <= 0.1));
        bool upBack = false;
        bool up = (xFloat < 0.2 && xFloat > -0.2) && (yFloat >= 0.2);
        bool upForward = false;*/

        bool downBack = IsPointInPolygon4(downBackArea.vectorArray, move);
        bool down = IsPointInPolygon4(downArea.vectorArray, move);
        bool downForward = IsPointInPolygon4(downForwardArea.vectorArray, move);
        //bool neutral = IsPointInPolygon4(neutralArea.vectorArray, move);
        bool forward = IsPointInPolygon4(forwardArea.vectorArray, move);

        
        if (downBack)
        {
            currentInput = 1;
        }
        if (down)
        {
            currentInput = 2;
        }
        if (downForward)
        {
            currentInput = 3;
        }
        if (move == Vector2.zero)
        {
            currentInput = 5;
        } 
        if (forward)
        {
            currentInput = 6;
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