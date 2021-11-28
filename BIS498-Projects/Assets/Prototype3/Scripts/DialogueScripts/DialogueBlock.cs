using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScriptableObject help from: https://www.youtube.com/watch?v=aPXvoWVabPY
[CreateAssetMenu(fileName = "New DialogueBlock", menuName = "Dialogue Block")]
public class DialogueBlock : ScriptableObject
{
    public string blockOwner;
    public string dialogueBlockTitle;
    public string[] dialogueBlockLines;
    public int currentDialogueIndex = 0;
    
    public string[] choicesArray;
    public int currentChoiceIndex = 0;

    public int maxWaitTime = 6;
}
