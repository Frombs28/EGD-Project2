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

    public void TriggerDialogue()
    {
        dialogue.name1 = playerName;
        dialogue.name2 = npc.myName;
        /*
         * put sentences change here; call upon the  
         */
        //sentences = manager.GetDialogue(id);
        sentences = npc.GetDialogue();
        dialogue.SetDialogue(sentences);
        FindObjectOfType<DialogueScript>().StartDialoguePlayer(dialogue);
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }
}
