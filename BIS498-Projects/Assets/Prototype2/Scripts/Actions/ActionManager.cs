using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private ActionLibrary _actionLibrary;

    private void Awake()
    {
        _actionLibrary = new ActionLibrary();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public BasicAction GetActionFromInput(InputPackage[] longestPossibleInput)
    {
        BasicAction result = null;

        if (longestPossibleInput[0].inputString.Contains("P"))
        {
            InputPackage[] currentMatch = 
            List<InputPackage[]> myPunchInstructions = _actionLibrary.punchInstructions;
            foreach(InputPackage[] instruction in myPunchInstructions)
            {
                bool instructionMatches = false;
                for (int j = 0; j < instruction.Length; j++)
                {
                    if ()
                    {
                        
                    }
                }
            }
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
