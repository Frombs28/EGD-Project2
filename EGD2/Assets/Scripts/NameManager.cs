using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    public string player;
    public string wheel;
    public string helm;
    public string rigging;
    public string cargo;
    public string crow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(int nameNum, string newName)
    {
        /* nameNum is an integer that represents which of the 6 objects
           in the game are getting a new name. The numbers are as follows:
           0 - player
           1 - wheel
           2 - helm
           3 - rigging
           4 - cargo
           5 - crow
           Any other value of nameNum will result in nothing happening except
           for a Debug.Log statement saying that some type of assignment was
           attempted.
        */
        if (nameNum == 0)
        {
            player = newName;
        }
        else if (nameNum == 1)
        {
            wheel = newName;
        }
        else if (nameNum == 2)
        {
            helm = newName;
        }
        else if (nameNum == 3)
        {
            rigging = newName;
        }
        else if (nameNum == 4)
        {
            cargo = newName;
        }
        else if (nameNum == 5)
        {
            wheel = newName;
        }
        else
        {
            Debug.Log("Tried to assign name " + newName + " to nameNum " + nameNum.ToString());
        }
    }
}
