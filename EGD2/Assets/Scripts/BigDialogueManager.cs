using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDialogueManager : MonoBehaviour
{
    public string[] playerWheelDialogue;
    public string[] playerHelmDialogue;
    public string[] playerRiggingDialogue;
    public string[] playerCargoDialogue;
    public string[] playerCrowDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] GetDialogue(int id)
    {
        string[] returnVal = new string[15];
        if (id == 0)
        {
            return returnVal;
        }
        else if (id == 1)
        {
            return returnVal;
        }
        else if (id == 2)
        {
            return returnVal;
        }
        else if (id == 3)
        {
            return returnVal;
        }
        else if (id == 4)
        {
            return returnVal;
        }
        else
        {
            returnVal[0] = "ERROR";
            returnVal[1] = "ERROR";
            return returnVal;
        }
    }
}
