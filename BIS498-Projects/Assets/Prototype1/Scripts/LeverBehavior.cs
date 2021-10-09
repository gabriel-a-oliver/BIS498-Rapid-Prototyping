using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    private bool upwardState = true;
    private bool downwardState = false;

    /*public delegate void FlipToDownState();
    public delegate void FlipToUpState();
    public static event FlipToDownState flipToDownState;
    public static event FlipToUpState flipToUpState;*/
    
    // Start is called before the first frame update
    void Start()
    {
        upwardState = true;
        downwardState = false;
        /*flipToDownState += flippingDown();
        flipToUpState += flippingUp();*/
    }

    private void OnDisable()
    {
        /*flipToDownState -= flippingDown();
        flipToUpState -= flippingUp();*/
    }

    private void flippingDown()
    {
        
    }

    private void flippingUp()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
