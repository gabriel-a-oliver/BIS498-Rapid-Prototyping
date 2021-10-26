using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayerController : MonoBehaviour
{
    public InputReader _inputReader;
    public InputManager _inputManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input Reader Behavior
        int currentInput;
        currentInput = _inputReader.InterpretInput();
        _inputReader.DisplayInput(currentInput);
        
        
    }
}
