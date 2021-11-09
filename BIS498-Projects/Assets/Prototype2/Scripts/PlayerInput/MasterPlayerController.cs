using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayerController : MonoBehaviour
{
    public InputReader _inputReader;
    public InputManager _inputManager;
    public ActionManager _actionManager;
    
    
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
