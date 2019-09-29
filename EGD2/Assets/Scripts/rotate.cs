using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    private float rotateX;
    private float rotateY;
    public float rotateSpeedX;
    public float rotateSpeedY;
    public float rotateTime = 0.5f;
    public bool fading = false;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (!fading)
        {
            rotateX += rotateSpeedX * Input.GetAxis("Mouse X");
            rotateY -= rotateSpeedY * Input.GetAxis("Mouse Y");
            rotateY = Mathf.Clamp(rotateY, -90, 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotateY, rotateX, 0), rotateTime);
        }
    }
}
