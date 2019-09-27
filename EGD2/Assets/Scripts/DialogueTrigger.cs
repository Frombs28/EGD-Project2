using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public string myName;
    public string playerName;

    public void TriggerDialogue()
    {
        dialogue.name1 = playerName;
        dialogue.name2 = myName;
        FindObjectOfType<DialogueScript>().StartDialoguePlayer(dialogue);
    }
}
