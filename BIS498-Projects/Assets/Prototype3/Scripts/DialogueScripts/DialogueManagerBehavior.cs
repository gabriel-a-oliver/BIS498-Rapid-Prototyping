using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private bool onlyOnce = true;
    private bool readyForNextLines = false;
    private bool currentConversationOver = true;


    private void OnEnable()
    {
        //Proto3EventManagerBehavior.startingDialogueBlock += StartingDialogueBlock;
        Proto3EventManagerBehavior.endingDialogueBlock += EndingDialogueBlock;
        
    }

    private void OnDisable()
    {
        //Proto3EventManagerBehavior.startingDialogueBlock -= StartingDialogueBlock;
        Proto3EventManagerBehavior.endingDialogueBlock += EndingDialogueBlock;

    }

    // Update is called once per frame
    void Update()
    {
        if (onlyOnce)
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                onlyOnce = false;
                StartCoroutine(LevelGameplay());
            }
        }
    }

    public void EndingDialogueBlock()
    {
        //Debug.Log("ready for next lines");
        readyForNextLines = true;
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

    private IEnumerator LevelGameplay()
    {
        GetConversationDialogues(GameObject.Find("NPC1"), GameObject.Find("NPC2"));
        Debug.Log("After Getting Conversation Dialogues:");
        Debug.Log("party 1:" + partyOne);
        Debug.Log("party 2:" + partyTwo);

        currentConversationOver = false;
        StartCoroutine(HaveConversation());
        //new WaitUntil(() => currentConversationOver);
        while (!readyForNextLines) yield return null;
        //this.gameObject.GetComponent<FlagManager>().nPCsIntroConversation = true;
        
        GetConversationDialogues(GameObject.Find("Player"), GameObject.Find("NPC2"));
        Debug.Log("After Getting Conversation Dialogues:");
        Debug.Log("party 1:" + partyOne);
        Debug.Log("party 2:" + partyTwo);
        currentConversationOver = false;
        StartCoroutine(HaveConversation());
        while (!readyForNextLines) yield return null;
        //this.gameObject.GetComponent<FlagManager>().playerIntroducesThemselves = true;
        
        GetConversationDialogues(GameObject.Find("NPC1"), GameObject.Find("Player"));
        Debug.Log("After Getting Conversation Dialogues:");
        Debug.Log("party 1:" + partyOne);
        Debug.Log("party 2:" + partyTwo);
        currentConversationOver = false;
        StartCoroutine(HaveConversation());
        while (!readyForNextLines) yield return null;
        //this.gameObject.GetComponent<FlagManager>(). = true;
        
        Debug.Log("end of gameplay");
    }

    private IEnumerator HaveConversation()
    {
        Debug.Log("conversation starting");
        myDialogueBox.SetActive(true);
        int partyOneDialogueBlocksLength = partyOneDialogueBlocks.Length;
        int partyTwoDialogueBlocksLength = partyTwoDialogueBlocks.Length;
        bool party1HasMoreBlocks = (partyOneDialogueBlocksLength > partyTwoDialogueBlocksLength);
        
        currentConversationOver = false;
        Debug.Log("Party1 has more dialogue blocks:" + party1HasMoreBlocks);

        DialogueBlock[] combinedListOfDialogueBlocks = new DialogueBlock[partyOneDialogueBlocksLength + partyTwoDialogueBlocksLength];

        // Combine all blocks into the order of conversation
        int iteration = 0;
        for (int i = 0; i < partyOneDialogueBlocksLength; i++)
        {
            combinedListOfDialogueBlocks[i + iteration] = partyOneDialogueBlocks[i];
            iteration++;
        }
        iteration = 0;
        for (int i = 0; i < partyTwoDialogueBlocksLength; i++)
        {
            combinedListOfDialogueBlocks[1 + i + iteration] = partyTwoDialogueBlocks[i];
            iteration++;
        }

        foreach (var currentDialogueBlock in combinedListOfDialogueBlocks)
        {
            readyForNextLines = false;
            yield return StartCoroutine(PerformDialogueBox(currentDialogueBlock));
        }
        
        Debug.Log("conversation over");
        currentConversationOver = true;
        myDialogueBox.gameObject.SetActive(false);
    }

    private IEnumerator PerformDialogueBox(DialogueBlock currentDialogueBlock)
    {
        myDialogueBox.GetComponent<DialogueBehavior>().SetDialogueBoxLines(currentDialogueBlock);
        myDialogueBox.GetComponent<DialogueBehavior>().StartDialogueBox();
        //yield return new WaitUntil(() => readyForNextLines);//new WaitForSeconds(currentDialogueBlock.maxWaitTime);
        while (!readyForNextLines) yield return null;
    }

    private int PromptDecision(DialogueBlock myChoices)
    {
        Debug.Log("Press Q to: " + myChoices.choicesArray[0] + ". or Press E to: " + myChoices.choicesArray[1] + ".");
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            return 0;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            return 1;
        }

        new WaitForSeconds(10);
        return -1;
    }
    
}
