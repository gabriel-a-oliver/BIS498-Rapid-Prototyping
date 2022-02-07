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
        
        GameObject uiInputStream = GameObject.Find("InputStream");
        
        GameObject firstBox = (GameObject)Resources.Load("2Direction", typeof(GameObject));
        //GameObject.Destroy(uiInputStream.transform.GetChild(0).transform.GetChild(0));
        Object.Instantiate(firstBox, uiInputStream.transform.GetChild(0).transform);
        //GameObject.Destroy(firstBox, 2f);
        
        GameObject secondBox = (GameObject)Resources.Load("3Direction", typeof(GameObject));
        //GameObject.Destroy(uiInputStream.transform.GetChild(1).transform.GetChild(0));
        Object.Instantiate(secondBox, uiInputStream.transform.GetChild(1).transform);
        //GameObject.Destroy(secondBox, 2f);
        
        GameObject thirdBox = (GameObject)Resources.Load("6Direction", typeof(GameObject));
        //GameObject.Destroy(uiInputStream.transform.GetChild(2).transform.GetChild(0));
        Object.Instantiate(thirdBox, uiInputStream.transform.GetChild(2).transform);
        //GameObject.Destroy(thirdBox, 2f);
        
        GameObject fourthBox = (GameObject)Resources.Load("BButton", typeof(GameObject));
        //GameObject.Destroy(uiInputStream.transform.GetChild(3).transform.GetChild(0));
        Object.Instantiate(fourthBox, uiInputStream.transform.GetChild(3).transform);
        //GameObject.Destroy(fourthBox, 2f);
        
        //GameObject.Destroy(uiInputStream.transform.GetChild(4).transform.GetChild(0));
        //GameObject.Destroy(uiInputStream.transform.GetChild(5).transform.GetChild(0));
        //GameObject.Destroy(uiInputStream.transform.GetChild(6).transform.GetChild(0));
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
