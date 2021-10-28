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

        BasicAction currentAction = _inputManager.InterpretCurrentInput(currentInput);

        /*
        if (currentAction != null)
        {
            _actionManager.AddToActionQueue(currentAction);
        }

        _actionManager.ActionQueueLifeTimeDecrement();

        if (endLag == 0 && !_actionManager.ActionQueueIsEmpty())
        {
            endLag = _actionManager.PerformNextAbility();
        }


        endLag--;
        if (endLag < 0)
        {
            endLag = 0;
        }*/
    }
}
