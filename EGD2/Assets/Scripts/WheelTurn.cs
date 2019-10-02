using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTurn : MonoBehaviour
{
    public GameObject boat;
    public bool spinWheel;
    Rigidbody rbdy;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        //rbdy = GetComponent<Rigidbody>();
        spinWheel = true;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (spinWheel == true)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * boat.transform.GetComponent<BoatMove>().last * 50);
        }
    }
    public void AllowSpin()
    {
        spinWheel = true;
        boat.GetComponent<BoatMove>().changeCourse = true;
    }
    public void StopSpin()
    {
        spinWheel = false;
        boat.GetComponent<BoatMove>().changeCourse = false;
    }
}
