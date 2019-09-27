using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Move : MonoBehaviour {

    public float speed;
    private Rigidbody rgd;
    private Vector3 mousePos;
    public Camera cam;
    private Vector3 camDir;
    private Vector3 camSid;
    public AudioSource footStep;
    bool playing = false;
    public Text txt;
    private rotate rotateScript;
    public List<AudioClip> aud;
    public float footstepTime = 0.5f;
    private float footTimer = 0f;
    public float moveLockTime = 1f;
    private CharacterController controller;
    Vector3 velocity;

    public bool isPlayerControllable = true;

    [Space]
    [SerializeField]
    private float deadRotationSpeed = .5f;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        rgd = GetComponent<Rigidbody>();
        footStep = GetComponent<AudioSource>();
        rotateScript = cam.GetComponent<rotate>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetPlayerControllable(bool state)
    {
        isPlayerControllable = state;
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (isPlayerControllable)
        {
            camDir = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
            camSid = new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;

            Vector3 fwd = Input.GetAxisRaw("Horizontal") * camSid;
            Vector3 sid = Input.GetAxisRaw("Vertical") * camDir;

            Vector3 move = fwd + sid;
            controller.Move(move * Time.deltaTime * speed);
            if (move != Vector3.zero)
                transform.forward = move;

            velocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && !playing || Mathf.Abs(Input.GetAxis("Vertical")) > 0 && !playing)
            {
                int i = Random.Range(0, aud.Count - 1);
                footTimer = 0;
                footStep.clip = aud[i];
                footStep.Play();
                playing = true;
            }
            if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
            {
                footStep.Stop();
                playing = false;
            }
        }
        if(playing)
        {
            footTimer += Time.deltaTime;
            if(footTimer > footstepTime)
            {
                playing = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(isPlayerControllable)
        {
            if(other.tag == "Teleporter")
            {
                txt.text = "Press E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    txt.text = "";
                    isPlayerControllable = false;
                    rotateScript.fading = true;               
                    //put teleport code here
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Teleporter")
        {
            txt.text = "";
        }
    }

    void Stop(float fadeTime)
    {
        Invoke("DenyMovement", fadeTime);
    }

    void DenyMovement()
    {
        isPlayerControllable = false;
        rotateScript.fading = true;
    }

    void Begin(float fadeTime)
    {
        Invoke("AllowMovement", fadeTime+moveLockTime);
    }

   void AllowMovement()
    {
        isPlayerControllable = true;
        rotateScript.fading = false;
    }
}
