using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueManagerBehavior : MonoBehaviour
{
    public GameObject myDialogueBox;
    [SerializeField] public bool dialogueBlockActivate;
    [SerializeField] private bool party1Turn;
    
    [SerializeField] private GameObject partyOne;
    [SerializeField] private DialogueBlock[] partyOneDialogueBlocks;
    [SerializeField] private int currentParty1DialogueBlockIndex;
    [SerializeField] private GameObject partyTwo;
    [SerializeField] private DialogueBlock[] partyTwoDialogueBlocks;
    [SerializeField] private int currentParty2DialogueBlockIndex;


    private void OnEnable()
    {
        Proto3EventManagerBehavior.startingDialogueBlock += StartingDialogueBlock;
        Proto3EventManagerBehavior.endingDialogueBlock += EndingDialogueBlock;
        
    }

    private void OnDisable()
    {
        Proto3EventManagerBehavior.startingDialogueBlock -= StartingDialogueBlock;
        Proto3EventManagerBehavior.endingDialogueBlock += EndingDialogueBlock;

    }

    // Start is called before the first frame update
    void Start()
    {
        LevelGameplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartingDialogueBlock()
    {
        dialogueBlockActivate = true;
        if (party1Turn)
        {
            myDialogueBox.GetComponent<DialogueBehavior>().SetDialogueBoxLines(partyOneDialogueBlocks[currentParty1DialogueBlockIndex].dialogueBlockLines);
        }
        else
        {
            myDialogueBox.GetComponent<DialogueBehavior>().SetDialogueBoxLines(partyTwoDialogueBlocks[currentParty2DialogueBlockIndex].dialogueBlockLines);
        }
        myDialogueBox.GetComponent<DialogueBehavior>().StartDialogueBox();

    }

    public void EndingDialogueBlock()
    {
        if (party1Turn)
        {
            party1Turn = false;
            currentParty1DialogueBlockIndex++;
        }
        else
        {
            party1Turn = true;
            currentParty2DialogueBlockIndex++;
        }

        dialogueBlockActivate = false;
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

        currentParty1DialogueBlockIndex = 0;
        currentParty2DialogueBlockIndex = 0;
        party1Turn = true;
    }
    
    private void PartiesConverse()
    {
        Debug.Log("conversation starting");
        int partyOneDialogueBlocksLength = partyOneDialogueBlocks.Length;
        int partyTwoDialogueBlocksLength = partyTwoDialogueBlocks.Length;
        bool party1MoreBlocks = (partyOneDialogueBlocksLength > partyTwoDialogueBlocksLength);
        bool conversationFinished = false;
        Debug.Log("Party1 has more dialogue blocks:" + party1MoreBlocks);
        // while both arrays are not complete, swap between each parties' blocks
        // trigger event for conversation start with party 1
        // hold until event for block concluded triggers
        // swap to party two and repeat

        
        for (int i = 0; !conversationFinished; i++)
        {
            Debug.Log("conversationLoop:" + i);
            if (!dialogueBlockActivate)
            {
                Proto3EventManagerBehavior.StartingDialogueBlockBehaviors();
            }

            if (party1MoreBlocks)
            {
                if (currentParty1DialogueBlockIndex >= partyOneDialogueBlocksLength)
                { 
                    conversationFinished = true;
                    Debug.Log("conversation finished from party1 blocks end");
                }
            }
            else
            {
                if (currentParty2DialogueBlockIndex >= partyTwoDialogueBlocksLength)
                {
                    conversationFinished = true;
                    Debug.Log("conversation finished from party2 blocks end");

                }
            }

            if (i >= 1)
            {
                conversationFinished = true;
                Debug.Log("conversation finished from safety i value:" + i);

            }
        }
    }
    
    private void LevelGameplay()
    {
        GetConversationDialogues(GameObject.Find("NPC1"), GameObject.Find("NPC2"));
        Debug.Log("After Getting Conversation Dialogues:");
        Debug.Log("party 1:" + partyOne);
        Debug.Log("part 2:" + partyTwo);
        PartiesConverse();
        Debug.Log("gameplay finished");
        
    }

    
}
