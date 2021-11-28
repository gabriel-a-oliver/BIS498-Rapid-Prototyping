using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueManagerBehavior : MonoBehaviour
{
    public GameObject partyOne;
    public GameObject partyTwo;

    [SerializeField] private DialogueBlock[] partyOneDialogueBlocks;
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
