using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public ActionLibrary _actionLibrary;
    private BasicAction[] _actionQueue;

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

        _actionQueue = new BasicAction[5]{null, null, null, null, null};
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
                result = _actionLibrary.actionList[i].Item2;
                i = myPunchInstructions.Count;
            }
        }
        if (longestMatch != null)
        {
            Debug.Log("Match: " + DisplayInstruction(longestMatch));
            //result = _actionLibrary.GetPunchAction(longestMatch);
        }


        return result;
    }
    
    public void AddToActionQueue(BasicAction currentAction)
    {
        // Bad implementation. instead just move everything to the side and add it to front
        /*bool addedSuccessfully = false;
        for (int i = 0; i < _actionQueue.Length; i++)
        {
            if (_actionQueue[i] == null)
            {
                _actionQueue[i] = currentAction;
                addedSuccessfully = true;
                i = _actionQueue.Length;
            }
        }

        if (!addedSuccessfully)
        {
            replace
        }*/
    }

    public void ActionQueueLifeTimeDecrement()
    {
        
    }

    public bool ActionQueueIsEmpty()
    {
        for (int i =0; i < _actionQueue.Length; i++)
        {
            if (_actionQueue[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    public int PerformNextAbility()
    {
        
        return 0;
    }
}
