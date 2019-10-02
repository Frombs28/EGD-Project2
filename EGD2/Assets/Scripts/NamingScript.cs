using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamingScript : MonoBehaviour
{

    public InputField inputField;
    public InputField playerField;
    string curString;
    NPCScript curNPC;
    public Move player;
    // Start is called before the first frame update
    void Start()
    {
        inputField.DeactivateInputField();
        inputField.gameObject.SetActive(false);
        playerField.gameObject.SetActive(true);
        playerField.ActivateInputField();
        player.UnlockMouse();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NameNewCharacter(NPCScript npc)
    {
        inputField.gameObject.SetActive(true);
        inputField.ActivateInputField();
        curNPC = npc;
        player.UnlockMouse();
        //npc.SetName(curString);
    }

    public void ChangeNPCName(string newName)
    {
        if (newName.Length < 2)
        {
            return;
        }
        curNPC.SetName(newName);
        inputField.DeactivateInputField();
        inputField.gameObject.SetActive(false);
        player.LockMouse();
    }

    public void ChangePlayerName(string newName)
    {
        if(newName.Length < 2)
        {
            return;
        }
        foreach (DialogueTrigger trigger in FindObjectsOfType<DialogueTrigger>()){
            trigger.SetPlayerName(newName);
            Debug.Log(trigger.name);
        }
        playerField.DeactivateInputField();
        playerField.gameObject.SetActive(false);
        player.LockMouse();
        Debug.Log(newName);
    }

}
