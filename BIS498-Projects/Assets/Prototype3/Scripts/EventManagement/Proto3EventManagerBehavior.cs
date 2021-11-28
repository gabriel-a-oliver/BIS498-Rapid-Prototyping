using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto3EventManagerBehavior : MonoBehaviour
{
    public delegate void StartDialogueBlock();
    public static event StartDialogueBlock startingDialogueBlock;

    public static void StartingDIalogueBlockBehaviors()
    {
        if (startingDialogueBlock != null)
        {
            startingDialogueBlock();
        }
    }
    
    public delegate void EndDialogueBlock();
    public static event EndDialogueBlock endingDialogueBlock;

    public static void EndingDIalogueBlockBehaviors()
    {
        if (endingDialogueBlock != null)
        {
            endingDialogueBlock();
        }
    }
    
    
    /*
    // Downward Events
    public delegate void FlipToDownState();
    public static event FlipToDownState flippingDown;
    public delegate void FlippedToDownState();
    public static event FlippedToDownState flippedDown;
    public delegate void FlipDownStart();
    public static event FlipDownStart flipDownStart;
    
    // Upward Events
    public delegate void FlipToUpState();
    public static event FlipToUpState flippingUp;
    public delegate void FlippedToUpState();
    public static event FlippedToUpState flippedUp;
    public delegate void FlipUpStart();
    public static event FlipUpStart flipUpStart;

    // Downward Events
    public static void FlippingDownBehaviors()
    {
        if (flippingDown != null)
        {
            flippingDown();
        }
    }
    public static void FlippedDownBehaviors()
    {
        if (flippedDown != null)
        {
            flippedDown();
        }
    }
    public static void FlipDownStartBehaviors()
    {
        if (flipDownStart != null)
        {
            flipDownStart();
        }
    }
    
    // Upward Events
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
    public static void FlipUpStartBehaviors()
    {
        if (flipUpStart != null)
        {
            flipUpStart();
        }
    }*/
}
