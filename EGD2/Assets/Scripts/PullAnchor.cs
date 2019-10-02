using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullAnchor : MonoBehaviour
{
    public bool anchorUp;
    public bool anchorDown;

    bool wPress;
    bool aPress;
    bool sPress;
    bool dPress;
    bool pull;

    bool trigger;

    int count;

    public GameObject player;
    public RectTransform spin;
    public Image arrowSpace;

    // Start is called before the first frame update
    void Start()
    {
        anchorUp = true;
        anchorDown = false;

        aPress = false;
        wPress = false;
        sPress = false;
        dPress = true;

        pull = false;

        trigger = true;

        count = 0;
        arrowSpace.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        {
            Debug.Log(count);
            if (Input.GetKeyDown(KeyCode.W) && dPress == true)
            {
                Debug.Log("W");
                wPress = true;
                dPress = false;
                count++;
                spin.Rotate(new Vector3(0f, 0f, -90f));
            }
            if (Input.GetKeyDown(KeyCode.A) && wPress == true)
            {
                Debug.Log("A");
                wPress = false;
                aPress = true;
                count++;
                spin.Rotate(new Vector3(0f, 0f, -90f));
            }
            if (Input.GetKeyDown(KeyCode.S) && aPress == true)
            {
                Debug.Log("S");
                aPress = false;
                sPress = true;
                count++;
                spin.Rotate(new Vector3(0f, 0f, -90f));
            }
            if (Input.GetKeyDown(KeyCode.D) && sPress == true)
            {
                Debug.Log("D");
                sPress = false;
                dPress = true;
                count++;
                spin.Rotate(new Vector3(0f, 0f, -90f));
            }
            if (count == 16)
            {
                if (anchorDown)
                {
                    PullUpAnchor();
                }
                else
                {
                    PutDownAnchor();
                }
            }
        }

        
    }

    public void TriggerAnchor ()
    {
        trigger = true;
        Debug.Log("Anchor");
        arrowSpace.enabled = true;
    }

    public void PullUpAnchor ()
    {
        player.GetComponent<Move>().UnlockPlayer();
        anchorUp = true;
        anchorUp = false;
        count = 0;
        arrowSpace.enabled = false;
        trigger = false;
    }

    public void PutDownAnchor()
    {
        player.GetComponent<Move>().UnlockPlayer();
        anchorDown = true;
        anchorUp = false;
        count = 0;
        arrowSpace.enabled = false;
        trigger = false;
    }
}
