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
    public PlayNotes notes;
    public GameObject boat;

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
        foreach (NPCScript npc in FindObjectsOfType<NPCScript>())
        {
            npc.PlayerNameReplace(newName);
        }
        playerField.DeactivateInputField();
        playerField.gameObject.SetActive(false);
        player.LockMouse();

        boat.GetComponent<BoatMove>().canMove = true;

        Debug.Log(newName);
    }

}
