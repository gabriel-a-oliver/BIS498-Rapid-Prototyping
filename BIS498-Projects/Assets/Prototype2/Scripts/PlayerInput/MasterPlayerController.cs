using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayerController : MonoBehaviour
{
    public InputReader _inputReader;
    public InputManager _inputManager;
    public ActionManager _actionManager;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;
    public GameObject box6;
    
    
    [SerializeField]private int endLag = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input Reader Behavior
        /*int currentInput;
        currentInput = _inputReader.InterpretInput();*/
        //_inputReader.DisplayInput(currentInput);
        string currentInput = _inputReader.GetFrameInput();
        //_inputReader.DisplayInput(currentInput);

        InputPackage[] longestPossibleInput = _inputManager.InterpretCurrentInput(currentInput);

        
        if (longestPossibleInput != null)
        {
            //Debug.Log("ButtonPressedDetected");
            BasicAction currentAction = _actionManager.GetActionFromInput(longestPossibleInput);
            if (currentAction != null)
            {
                //Debug.Log("adding to action queue");
                _actionManager.AddToActionQueue(currentAction);
                _actionManager.DisplayActionQueue();
            }
        }

        if (!_actionManager.ActionQueueIsEmpty())
        {
            _actionManager.ActionQueueLifeTimeDecrement();
            if (endLag == 0)
            {
                
                //Transform currentBox = box1.transform.GetChild(0);
                if (box1.transform.childCount > 0)
                {
                    Destroy(box1.transform.GetChild(0));
                }
                //currentBox = box2.transform.GetChild(0);
                if (box2.transform.childCount > 0) 
                {
                    Destroy(box2.transform.GetChild(0));
                }
                //currentBox = box3.transform.GetChild(0);
                if (box3.transform.childCount > 0)
                {
                    Destroy(box3.transform.GetChild(0));
                }
                //currentBox = box4.transform.GetChild(0);
                if (box4.transform.childCount > 0)
                {
                    Destroy(box4.transform.GetChild(0));
                }
                //currentBox = box5.transform.GetChild(0);
                if (box5.transform.childCount > 0)
                {
                    Destroy(box5.transform.GetChild(0));
                }
                //currentBox = box6.transform.GetChild(0);
                if (box6.transform.childCount > 0)
                {
                    Destroy(box6.transform.GetChild(0));
                }

                
                
                
                //Debug.Log("Perform next ability");
                endLag = _actionManager.PerformNextAbility();
                //Debug.Log("new endlag: " + endLag);
                
                
                
                
                
            }
        }

        


        endLag--;
        if (endLag < 0)
        {
            endLag = 0;
        }
    }
}
