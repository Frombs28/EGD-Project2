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
           0 - wheel
           1 - helm
           2 - rigging
           3 - cargo
           4 - crow
           5 - player
           Any other value of nameNum will result in nothing happening except
           for a Debug.Log statement saying that some type of assignment was
           attempted.
        */
        if (nameNum == 5)
        {
            player = newName;
        }
        else if (nameNum == 0)
        {
            wheel = newName;
        }
        else if (nameNum == 1)
        {
            helm = newName;
        }
        else if (nameNum == 2)
        {
            rigging = newName;
        }
        else if (nameNum == 3)
        {
            cargo = newName;
        }
        else if (nameNum == 4)
        {
            wheel = newName;
        }
        else
        {
            Debug.Log("Tried to assign name " + newName + " to nameNum " + nameNum.ToString());
        }
    }

    public string getName(int id)
    {
        if (id == 0)
        {
            return wheel;
        }
        else if (id == 1)
        {
            return helm;
        }
        else if (id == 2)
        {
            return rigging;
        }
        else if (id == 3)
        {
            return cargo;
        }
        else if (id == 4)
        {
            return crow;
        }
        else
        {
            Debug.Log("Tried to get name of id number " + id);
            return "ERROR";
        }
    }
}
