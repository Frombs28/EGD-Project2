using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalimbaPatterns : MonoBehaviour
{
    public AudioClip[] beginnerPatterns;
    public AudioClip[] intermediatePatterns;
    public AudioClip[] advancedPatterns;
    public float timeBase;
    public float timeRange;

    private float rand;
    private float currentTime;
    private AudioSource aud;
    private AudioClip[] patterns;

    // Start is called before the first frame update
    void Start()
    {
        patterns = beginnerPatterns;
        aud = gameObject.GetComponent<AudioSource>();
        rand = Random.Range(-timeRange, timeRange);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeBase + rand)
        {
            int index = Random.Range(0, patterns.Length);
            aud.clip = patterns[index];
            aud.Play();
            currentTime = 0;
            rand = Random.Range(-timeRange, timeRange);
        }
    }
}
