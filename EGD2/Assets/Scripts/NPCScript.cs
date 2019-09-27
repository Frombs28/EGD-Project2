using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public string name;
    public GameObject NameManager;
    public int nameNum;
    bool named;
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
        name = newName;
        named = true;
    }

    public void Talk()
    {
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}
