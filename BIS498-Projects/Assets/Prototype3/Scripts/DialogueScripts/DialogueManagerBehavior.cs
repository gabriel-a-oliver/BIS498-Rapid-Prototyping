using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueManagerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject partyOne;
    [SerializeField] private DialogueBlock[] partyOneDialogueBlocks;
    [SerializeField] private GameObject partyTwo;
    [SerializeField] private DialogueBlock[] partyTwoDialogueBlocks;

    
    // Start is called before the first frame update
    void Start()
    {
        LevelGameplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetConversationDialogues(GameObject _partyOne, GameObject _partyTwo)
    {
        partyOne = _partyOne;
        PartitionedDialogueManager partyOnePartitionedDialogueManager =
            partyOne.GetComponent<PartitionedDialogueManager>();
        partyTwo = _partyTwo;
        PartitionedDialogueManager partyTwoPartitionedDialogueManager =
            partyTwo.GetComponent<PartitionedDialogueManager>();

        
        partyOneDialogueBlocks = partyOnePartitionedDialogueManager.GetDialogueForCharacter(partyTwo);
        partyTwoDialogueBlocks = partyTwoPartitionedDialogueManager.GetDialogueForCharacter(partyOne);
    }
    
    private void PartiesConverse()
    {
        int partyOneDialogueBlocksLength = partyOneDialogueBlocks.Length;
        int partyTwoDialogueBlocksLength = partyTwoDialogueBlocks.Length;

        // while both arrays are not complete, swap between each parties' blocks
        // trigger event for conversation start with party 1
        // hold until event for block concluded triggers
        // swap to party two and repeat
        
        
    }
    
    private void LevelGameplay()
    {
        GetConversationDialogues(GameObject.Find("NPC1"), GameObject.Find("NPC2"));
        Debug.Log("After Getting Conversation Dialogues:");
        Debug.Log("party 1:" + partyOne);
        Debug.Log("part 2:" + partyTwo);
        PartiesConverse();
        
    }

    
}
