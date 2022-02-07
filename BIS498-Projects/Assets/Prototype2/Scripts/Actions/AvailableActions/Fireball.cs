using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BasicAction
{
    private string actionName = "Fireball";
    private int endLag = 15;
    private int actionQueueLifetime = 10;

    public override string GetActionName()
    {
        return actionName;
    }

    public override int GetEndLag()
    {
        return endLag;
    }

    public override void PerformActionBehavior()
    {
        Debug.Log("Performing ability: " + actionName);
    }

    public override int GetActionQueueLifeTime()
    {
        return actionQueueLifetime;
    }

    public override void SetActionQueueLifeTime(int newQueueLifeTime)
    {
        actionQueueLifetime = newQueueLifeTime;
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        SetEndLag(this.endLag);
        actionName = "Fireball: " + this.endLag;
    }

    public override int GetEndLag()
    {
        return endLag;
    }
    
    public override void PerformAbility()
    {
        Debug.Log("Performing ability: " + actionName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
