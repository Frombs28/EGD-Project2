using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public bool isFishing = false;
    [SerializeField]
    [Range(0,1)]
    private float fishingChance = .05f;
    [SerializeField]
    private float timeBetweenCheck = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
