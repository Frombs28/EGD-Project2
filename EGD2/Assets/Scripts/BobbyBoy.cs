using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbyBoy : MonoBehaviour
{
    public float speed;
    public float amp;
    Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        speed = speed + Random.Range(0, 1f);
        amp = amp + Random.Range(0f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = origPos;
        newPos.y += Mathf.Sin(Time.time*speed)*amp;
        transform.position = newPos;
    }
}
