using System.Collections;
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
    public int[] myArray;
    public Move player;
    bool isDay = true;
    NamingScript nameScript;
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
        nameScript = FindObjectOfType<NamingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerNameReplace(string newName)
    {
        for(int i = 0; i < myDialogue.Length; i++)
        {
            string sentence = myDialogue[i];
            sentence = sentence.Replace("@", newName);
            Debug.Log(sentence);
        }
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
        if(day >= 2 && !named)
        {
            nameScript.NameNewCharacter(this);
            return;
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
        talkedTo = true;
        string[] returnVal;
        if(day == 1)
        {
            returnVal = new string[3];
            int i = Random.Range(0, 3);

            returnVal[0] = player.dialogue[myArray[0]];
            returnVal[1] = myDialogue[i];
            returnVal[2] = player.dialogue[myArray[i]];
            return returnVal;
        }
        if(day == 2)
        {
            returnVal = new string[5];
            int i = Random.Range(0, 4);
            if (isDay)
       		{
            	returnVal[0] = player.dialogue[0];
        	}
        	else
        	{
            	returnVal[0] = player.dialogue[myArray[1]];
        	}
            returnVal[1] = myDialogue[i];
            returnVal[2] = player.dialogue[myArray[i]];
            int j = Random.Range(0, 4);
            while(j == i)
            {
                j = Random.Range(0, 4);
            }
            returnVal[3] = myDialogue[j];
            returnVal[4] = player.dialogue[myArray[j]];
            return returnVal;
        }
        returnVal = new string[5];
        int x;
        if (isDay)
        {
            x = Random.Range(4, 9);
            returnVal[0] = player.dialogue[0];
        }
        else
        {
            x = Random.Range(14, 19);
            returnVal[0] = player.dialogue[1];
        }
        
        returnVal[1] = myDialogue[x];
        returnVal[2] = player.dialogue[myArray[x]];
        int y = Random.Range(9, 14);
        while (y == x)
        {
            y = Random.Range(9, 14);
        }
        //returnVal[2] = player.dialogue[myArray[y]];
        returnVal[3] = myDialogue[y];
        returnVal[4] = player.dialogue[myArray[y]];
        return returnVal;
    }

    public string[] GetOneLiner()
    {
        string[] returnVal = new string[1];
        if(day == 1)
        {
            int i = Random.Range(0, 3);
            returnVal[0] = myDialogue[i];
            return returnVal;
        }
        if(day == 2)
        {
            int i = Random.Range(0, 3);
            returnVal[0] = myDialogue[i];
            return returnVal;
        }
        returnVal[0] = myDialogue[24];
        return returnVal;
    }

    public void RefreshDialogue()
    {
        talkedTo = false;
        if (isDay)
        {
            isDay = false;
        }
        else
        {
            isDay = true;
        }
    }

    public bool IsTalkedTo()
    {
        return talkedTo;
    }

}
