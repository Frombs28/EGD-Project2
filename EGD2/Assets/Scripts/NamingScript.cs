using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamingScript : MonoBehaviour
{

    public InputField inputField;
    public InputField playerField;
    string curString;
    private NPCScript curNPC;
    public Move player;
    // Start is called before the first frame update
    void Start()
    {
        inputField.DeactivateInputField();
        inputField.gameObject.SetActive(false);
        playerField.gameObject.SetActive(true);
        playerField.ActivateInputField();
        player.UnlockMouse();
        Debug.Log(playerField.isActiveAndEnabled);
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
        Debug.Log(newName);
        if (newName.Length == 0)
        {
            return;
        }
        foreach (DialogueTrigger trigger in FindObjectsOfType<DialogueTrigger>()){
            trigger.SetPlayerName(newName);
        }
        playerField.DeactivateInputField();
        playerField.gameObject.SetActive(false);
        player.LockMouse();
        Debug.Log(newName);
    }

}
