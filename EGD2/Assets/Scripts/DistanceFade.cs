using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFade : MonoBehaviour
{
    //rendering mode cannot be on opaque!!!
    public float maxDistance = 50f;
    public float minDistance = 10f;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = rend.material.color;
        float alpha = Mathf.InverseLerp (maxDistance, minDistance,
        Vector3.Distance (Camera.main.transform.position, transform.position));
        Debug.Log(rend.material.color.a);
        rend.material.color = new Color(color.r, color.b, color.g, alpha);
    }
}
