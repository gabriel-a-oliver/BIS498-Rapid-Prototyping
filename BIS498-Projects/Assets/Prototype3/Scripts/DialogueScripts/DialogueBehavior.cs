using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


// Help from: https://www.youtube.com/watch?v=8oTYabhj248
public class DialogueBehavior : MonoBehaviour
{
    [SerializeField] private DialogueManagerBehavior dmb;
    
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI ownerComponent;

    public string[] lines;
    public float textSpeed;

    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDialogueBoxLines(DialogueBlock newBlock)
    {
        lines = newBlock.dialogueBlockLines;
        ownerComponent.text = newBlock.blockOwner;
    }
    
    public void StartDialogueBox()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogueBox();
        }
    }

    private void EndDialogueBox()
    {
        dmb.EndingDialogueBlock();
        
        //gameObject.SetActive(false);
    }
}
