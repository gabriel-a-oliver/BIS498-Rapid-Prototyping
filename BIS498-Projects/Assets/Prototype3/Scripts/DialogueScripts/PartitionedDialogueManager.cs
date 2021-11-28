using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartitionedDialogueManager : MonoBehaviour
{
    public int characterID = 0;

    public GameObject relationship1Character;
    public DialogueBlock[] relationship1DialogueBlock;

    public GameObject relationship2Character;
    public DialogueBlock[] relationship2DialogueBlock;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DialogueBlock[] GetDialogueForCharacter(GameObject otherCharacter)
    {
        int caseOne = relationship1Character.GetComponent<PartitionedDialogueManager>().characterID;
        int caseTwo = relationship2Character.GetComponent<PartitionedDialogueManager>().characterID;

        if (otherCharacter == relationship1Character)
        {
            return relationship1DialogueBlock;
        }
        if (otherCharacter == relationship2Character)
        {
            return relationship2DialogueBlock;
        }
        Debug.Log("Error retrieving dialogue block array from: " + otherCharacter.name);
        return null;
    }
    
}
