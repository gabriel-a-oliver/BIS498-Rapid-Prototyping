using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public ActionLibrary _actionLibrary;

    private void Awake()
    {
        if (_actionLibrary == null)
        {
            _actionLibrary = this.gameObject.GetComponent<ActionLibrary>();
            if (_actionLibrary == null)
            {
                _actionLibrary = this.gameObject.AddComponent<ActionLibrary>();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void DisplayInstruction(InputPackage[] myInstruction)
    {
        string result = myInstruction[0].inputString;
        for (int i = 1; i < myInstruction.Length; i++)
        {
            //result += 
        }
    }
    
    

    public BasicAction GetActionFromInput(InputPackage[] longestPossibleInput)
    {
        BasicAction result = null;

        InputPackage[] longestMatch = null;
        InputPackage[] currentInstruction = null;
        List<InputPackage[]> myPunchInstructions = _actionLibrary.punchInstructions;
        //Debug.Log("myPunchInstructions firstInstruction: ");
        //DisplayInstruction(myPunchInstructions[0]);
        for (int i = 0; i < myPunchInstructions.Count; i++)
        {
            currentInstruction = myPunchInstructions[i];

            for (int j = 0; j < currentInstruction.Length; j++)
            {
                if (!currentInstruction[j].inputString.Equals(longestPossibleInput[j].inputString))
                {
                    j = currentInstruction.Length;
                } else
                if (j == currentInstruction.Length - 1)
                {
                    longestMatch = currentInstruction;
                }
            }

            if (longestMatch != null)
            {
                i = myPunchInstructions.Count;
            }
        }

        if (longestMatch != null)
        {
            Debug.Log("Match");
        }
        
        
        
        /*int longestMatchingLength = 0;
        if (longestPossibleInput[0].inputString.Contains("P"))
        {
            InputPackage[] currentMatch = null;
            List<InputPackage[]> myPunchInstructions = _actionLibrary.punchInstructions;
            
            
            
            foreach(InputPackage[] instruction in myPunchInstructions)
            {
                bool exactMatch = false;
                bool instructionMatches = false;
                for (int j = 0; j < instruction.Length; j++)
                {
                    if (!instruction[j].Equals(longestPossibleInput[j]))
                    {
                        currentMatch = null;
                        break;
                    }
                }
            }
        }*/
        
        
        return result;
    }
    
    public void AddToActionQueue(BasicAction currentAction)
    {
        
    }

    public void ActionQueueLifeTimeDecrement()
    {
        
    }

    public bool ActionQueueIsEmpty()
    {

        return false;
    }

    public int PerformNextAbility()
    {

        return 0;
    }
}
