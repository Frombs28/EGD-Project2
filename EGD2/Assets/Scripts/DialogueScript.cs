using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    Queue<string> sentences;
    Queue<string> names;
    Queue<int> nameOrder;
    public Text nameOne;
    public Text nameTwo;
    public Text dialogueText;
    public Animator animator;
    bool playerTalking;
    public string name1;
    public string name2;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialoguePlayer(Dialogue dialogue)
    {
        playerTalking = true;
        StartDialogue(dialogue);
    }

    public void StartDialogueNPC(Dialogue dialogue)
    {
        playerTalking = false;
        StartDialogue(dialogue);
    }

    void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation between " + dialogue.name1 + " and " + dialogue.name2);
        animator.SetBool("isOpen", true);
        sentences.Clear();
        name1 = dialogue.name1;
        name2 = dialogue.name2;
        for(int i = 0; i < dialogue.sentences.Length; i++)
        {
            string sentence = dialogue.sentences[i];
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(playerTalking)
        {
            nameOne.text = name1;
            nameTwo.text = "";
            playerTalking = false;
        }
        else
        {
            nameOne.text = "";
            nameTwo.text = name2;
            playerTalking = true;
        }
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //Debug.Log("Ending Conversation!");
        nameOne.text = "";
        nameTwo.text = "";
        dialogueText.text = "";
        animator.SetBool("isOpen", false);
    }
}
