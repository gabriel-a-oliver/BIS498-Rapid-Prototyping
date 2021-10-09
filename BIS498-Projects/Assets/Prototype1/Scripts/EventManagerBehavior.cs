using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerBehavior : MonoBehaviour
{

    public delegate void FlipToDownState();
    public static event FlipToDownState flippingDown;
    public delegate void FlipToUpState();
    public static event FlipToUpState flippingUp;

    public static void FlippingDownBehaviors()
    {
        if (flippingDown != null)
        {
            flippingDown();
        }
    }

    public static void FlippingUpBehaviors()
    {
        if (flippingUp != null)
        {
            flippingUp();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
