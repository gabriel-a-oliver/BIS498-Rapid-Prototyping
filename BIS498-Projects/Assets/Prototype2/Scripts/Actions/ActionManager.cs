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

    private string DisplayInstruction(InputPackage[] myInstruction)
    {
        string result = myInstruction[0].inputString;
        for (int i = 1; i < myInstruction.Length; i++)
        {
            result += ", " + myInstruction[i].inputString; 
        }
        //Debug.Log(result);
        return result;
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
            //string debug = DisplayInstruction(myPunchInstructions[i]);
            //Debug.Log("checking instruction " + i + ": " + debug);
            currentInstruction = myPunchInstructions[i];

            for (int j = 0; j < currentInstruction.Length; j++)
            {
                if (!currentInstruction[j].inputString.Equals(longestPossibleInput[j].inputString))
                {
                    //Debug.Log("Not a match");
                    j = currentInstruction.Length;
                } else
                if (j == currentInstruction.Length - 1)
                {
                    //Debug.Log("found a match 1");
                    longestMatch = currentInstruction;
                }
            }
            if (longestMatch != null)
            {
                //Debug.Log("found a match 2");
                i = myPunchInstructions.Count;
            }
        }
        if (longestMatch != null)
        {
            Debug.Log("Match: " + DisplayInstruction(longestMatch));
            ActionLibrary.Tuple<InputPackage[], InputPackage[]> myKey = ActionLibrary.Tuple.Create(longestMatch,longestMatch);
            result = _actionLibrary.actionDictionary[myKey];
        }


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
