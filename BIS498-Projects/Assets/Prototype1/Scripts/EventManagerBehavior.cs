using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerBehavior : MonoBehaviour
{

    public delegate void FlipToDownState();
    public static event FlipToDownState flippingDown;
    public delegate void FlippedToDownState();
    public static event FlippedToDownState flippedDown;
    public delegate void FlipToUpState();
    public static event FlipToUpState flippingUp;
    public delegate void FlippedToUpState();
    public static event FlippedToUpState flippedUp;

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
    
    public static void FlippedUpBehaviors()
    {
        if (flippedUp != null)
        {
            flippedUp();
        }
    }
    public static void FlippedDownBehaviors()
    {
        if (flippedDown != null)
        {
            flippedDown();
        }
    }
}
