using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public string myName;
    //public GameObject NameManager;
    //public int nameNum;
    bool named;
    public int id = 0;
    public string[] myDialogue;
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
    }

    public void Talk()
    {
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
        string[] returnVal = myDialogue;
        return returnVal;
    }

}
