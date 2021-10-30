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
