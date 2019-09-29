using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    string[] sentences;
    public string name1;
    public string name2;
    public void SetDialogue(string[] newSentences)
    {
        sentences = newSentences;
    }
    public int Length()
    {
        return sentences.Length;
    }
    public string Get(int i)
    {
        return sentences[i];
    }
}
