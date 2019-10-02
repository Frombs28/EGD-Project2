using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public string myName;
    public string playerName;
    public string[] sentences;
    //public BigDialogueManager manager;
    //public NameManager nm;
    NPCScript npc;
    int id;

    private void Start()
    {
        //manager = FindObjectOfType<BigDialogueManager>();
        //nm = FindObjectOfType<NameManager>();
        npc = gameObject.GetComponent<NPCScript>();
        id = npc.GetID();
    }

    public void TriggerDialogue(int i)
    {
        dialogue.name1 = playerName;
        dialogue.name2 = npc.myName;
        // If the npc has not been talked to, do the dialogue.
        // Other wise, do the one liner.
        if (!npc.IsTalkedTo())
        {
            sentences = npc.GetDialogue();
            
        }
        else
        {
            sentences = npc.GetOneLiner();
        }
        dialogue.SetDialogue(sentences);
        FindObjectOfType<DialogueScript>().StartDialoguePlayer(dialogue);
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }
}
