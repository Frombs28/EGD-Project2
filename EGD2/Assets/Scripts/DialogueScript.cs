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
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        nameOrder = new Queue<int>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation between " + dialogue.name1 + " and " + dialogue.name2);
        animator.SetBool("isOpen", true);
        sentences.Clear();
        names.Clear();
        nameOrder.Clear();
        for(int i = 0; i < dialogue.sentences.Length; i++)
        {
            string sentence = dialogue.sentences[i];
            int person = dialogue.name[i];
            string name;
            int nameNum;
            if(person == 0)
            {
                name = dialogue.name1;
                nameNum = 0;
            }
            else
            {
                name = dialogue.name2;
                nameNum = 1;
            }
            sentences.Enqueue(sentence);
            names.Enqueue(name);
            nameOrder.Enqueue(nameNum);
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
        string name = names.Dequeue();
        int nameNum = nameOrder.Dequeue();
        if(nameNum == 0)
        {
            nameOne.text = name;
            nameTwo.text = "";
        }
        else
        {
            nameOne.text = "";
            nameTwo.text = name;
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
