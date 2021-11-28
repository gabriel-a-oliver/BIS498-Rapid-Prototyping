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

    public string[] choicesArray;
}
