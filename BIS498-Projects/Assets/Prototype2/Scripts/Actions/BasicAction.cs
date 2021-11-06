using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BasicAction
{

    public abstract int GetEndLag();
    public abstract string GetActionName();
    public abstract void PerformActionBehavior();
    public abstract int GetActionQueueLifeTime();
    public abstract void SetActionQueueLifeTime(int newQueueLifeTime);

    /*public string actionName = "Default BasicAction";
    public int actionQueueLifetime = 5;
    private int endLag;

    virtual public int GetEndLag()
    {
        return endLag;
    }

    public void SetEndLag(int myEndLag)
    {
        endLag = myEndLag;
    }

    abstract public void PerformAbility();/*
    {
        Debug.Log("Performing ability: " + actionName);
    }#1#

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Action Triggered: " + actionName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
