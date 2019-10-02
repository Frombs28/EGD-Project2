using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    Vector3 startSpeed;
    Vector3 direction;
    public float maxVelocity;
    public float last;
    //Rigidbody rb;

    public bool changeCourse;
    public bool canMove;
    public GameObject wheel;

    // Start is called before the first frame update
    void Start()
    {
        changeCourse = true;
        canMove = true;

        //rb = GetComponent<Rigidbody>();
        maxVelocity = 10f;
        startSpeed = new Vector3(1f, 0f, 1f);
        startSpeed *= maxVelocity;
        direction = startSpeed;

        last = 0f;

        //rb.velocity = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (changeCourse == true)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    last = Input.GetAxis("Horizontal");
                }
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * last * maxVelocity);

                direction = new Vector3(Mathf.Sin(transform.rotation.y), 0, Mathf.Cos(transform.rotation.y));
                direction *= maxVelocity;
            }
            transform.position += direction * Time.deltaTime;
        }
    }

    public float turnToAngle(float f)
    {
        float turn = Mathf.PI * 2;
        while (f > Mathf.PI)
        {
            f -= turn;
        }
        while (f < -Mathf.PI)
        {
            f += turn;
        }
        return f;
    }

    public Vector3 TurnBoat()
    {
        //Can be changed to whichever dimension we need it to be
        //Is the number that spins the boat
        float wheelTurn = wheel.transform.rotation.x;
        //wheelTurn = turnToAngle(wheelTurn);

        

        return Vector3.zero;
    }
}
