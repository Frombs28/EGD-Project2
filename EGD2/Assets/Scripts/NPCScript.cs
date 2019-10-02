﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public string myName;
    //public GameObject NameManager;
    //public int nameNum;
    bool named;
    bool talkedTo;
    public int id = 0;
    public string[] myDialogue;
    public int day = 1;
    /*
     * This id number will allow us to number NPCs so all scripts know who they are.
     * Set up these ID numbers in the inspector
     * 0: Wheel
     * 1: Helm
     * 2: Rigging
     * 3: Cargo
     * 4: Crow
     */
    // Start is called before the first frame update
    void Start()
    {
        named = false;
        talkedTo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsNamed()
    {
        return named;
    }

    public void SetName(string newName)
    {
        myName = newName;
        named = true;
        Debug.Log("Set name to " + myName);
    }

    public void Talk()
    {
        if(day == 2 && !named)
        {
            //name the object
        }

        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public void Cheer()
    {
        // this function is for NPCs to celebrate the player's BOPPIN music
    }

    public int GetID()
    {
        return id;
    }

    public string[] GetDialogue()
    {
        string[] returnVal = new string[4];
        if(day == 1)
        {
            int i = Random.Range(0, 2);
            returnVal[1] = myDialogue[i];
        }
        for(int i = 0; i < 4; i++)
        {
            returnVal[i] = myDialogue[i];
        }
        talkedTo = true;
        return returnVal;
    }

    public string[] GetOneLiner()
    {
        string[] returnVal = new string[2];
        returnVal[0] = myDialogue[0];
        returnVal[1] = myDialogue[4];
        return returnVal;
    }

    public void RefreshDialogue()
    {
        talkedTo = false;
    }

    public bool IsTalkedTo()
    {
        return talkedTo;
    }

}
