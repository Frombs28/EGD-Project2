using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    public Image memory;
    public Sprite one;
    public Sprite two;
    public float fadeTime;
    float startTime;
    bool viewed;
    // Start is called before the first frame update
    void Start()
    {
        memory.canvasRenderer.SetAlpha(0.0f);
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
        memory.CrossFadeAlpha(1.0f, fadeTime, false);
        Invoke("Step2", fadeTime);
    }

    void Step2()
    {
        memory.CrossFadeAlpha(0.0f, fadeTime, false);
        Invoke("Step3", fadeTime);
    }

    void Step3()
    {
        memory.sprite = two;
        memory.CrossFadeAlpha(1.0f, fadeTime, false);
        Invoke("Step4", fadeTime);
    }

    void Step4()
    {
        memory.CrossFadeAlpha(0.0f, fadeTime, false);
        Invoke("End", fadeTime);
    }

    void End()
    {
        viewed = true;
        FindObjectOfType<Move>().LockMouse();
    }

    public bool HasBeenViewed()
    {
        return viewed;
    }
}
