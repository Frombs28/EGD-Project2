using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryEnd : MonoBehaviour
{
    public Image memory;
    public Sprite one;
    //public Sprite two;
    public float fadeTime;
    float startTime;
    bool viewed;
    public bool final = false;
    // Start is called before the first frame update
    void Start()
    {
        memory.canvasRenderer.SetAlpha(0.0f);
        memory.gameObject.SetActive(false);
        viewed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Begin()
    {
        memory.sprite = one;
        memory.canvasRenderer.SetAlpha(0.0f);
        memory.gameObject.SetActive(true);
        memory.CrossFadeAlpha(1.0f, fadeTime, false);
    }
}
