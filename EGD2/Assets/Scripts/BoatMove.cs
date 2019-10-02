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
    public GameObject player;
    public GameObject water;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        changeCourse = false;
        canMove = false;

        //rb = GetComponent<Rigidbody>();
        startSpeed = new Vector3(0f, 0f, 1f);
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
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    last = Input.GetAxis("Horizontal");
                }
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * last * maxVelocity);
                cam.transform.RotateAround(transform.position, transform.up, Time.deltaTime * last * maxVelocity);
                player.transform.RotateAround(transform.position, transform.up, Time.deltaTime * last * maxVelocity);

                direction = transform.forward;
                direction *= maxVelocity;
            }
            transform.position += direction * Time.deltaTime;
            player.GetComponent<CharacterController>().Move(direction * Time.deltaTime);
            water.transform.position += direction * Time.deltaTime;
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
