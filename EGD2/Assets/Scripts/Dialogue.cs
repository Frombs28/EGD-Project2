using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string[] sentences;
    public int[] name;
    public string name1;
    public string name2;
}
