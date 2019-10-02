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
    private LineRenderer fishingLine;
    [SerializeField]
    private GameObject fishy = null;
    [SerializeField]
    private GameObject p0;
    [SerializeField]
    private GameObject p1;
    [SerializeField]
    private GameObject p2;
    [SerializeField]
    private float epsilon = .001f;
    Vector3 p0Init, p1Init, p2Init;
    [SerializeField]
    private float lineMoveSpeed = 1f;
    [SerializeField]
    private float lineCastTime = 2f;
    private float startTime = 0.0f;
    [SerializeField]
    private int drawInToCastRatio = 2;
    Rigidbody fishyRb;
    // Start is called before the first frame update
    void Start()
    {
        fishingLine = GetComponent<LineRenderer>();
        fishingLine.positionCount = 0;
        p0Init = p0.transform.position;
        p1Init = p1.transform.position;
        p2Init = p2.transform.position;
        StartFishing();
        fishyRb = fishy.GetComponent<Rigidbody>();
        fishyRb.useGravity = false;
        fishy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFishing){
            MoveLine();
        } 
    }

    void StartFishing(){
        //throw out line here
        StartCoroutine("CastLine");
        Debug.Log("casting!!1");
    }
    IEnumerator CastLine(){
        int counter = 0;
        fishingLine.positionCount = 0;
        float step = 1/lineCastTime;
        for(float t = 0.0f; t-1.0<=epsilon;t+=step*Time.deltaTime){
            fishingLine.positionCount = counter+1;
            Vector3 newPoint = BezierQuad(t, p0.transform.position, p1.transform.position, p2.transform.position);
            fishingLine.SetPosition(counter, newPoint);
            counter++;
            yield return null;
        }
        startTime = Time.time;
        isFishing = true;
        StartCoroutine("DrawLineIn");
    }

    IEnumerator DrawLineIn(){
        int counter = fishingLine.positionCount;
        float step = drawInToCastRatio/(float)fishingLine.positionCount;
        isFishing = false;
        Debug.Log("Step is: "+ step);
        fishy.SetActive(true);
        for(float t = 1.0f; t-0.0f>=epsilon;t-=step){
            Debug.Log(counter);
            if(counter<=0){
                fishingLine.positionCount = 0;
                break;
            }
            fishingLine.positionCount = counter;
            Vector3 newPoint = BezierQuad(t, p0.transform.position, p1.transform.position, p2.transform.position);
            fishingLine.SetPosition(counter-1, newPoint);
            fishy.transform.position = newPoint;
            counter-=drawInToCastRatio;
            yield return null;
        }
        fishingLine.positionCount = 0;
        fishyRb.useGravity = true;
        //To Do: have fishy stay/flop for 2 seconds and then set active to false
    }

    private Vector3 BezierQuad(float t, Vector3 p0, Vector3 p1, Vector3 p2){
        return (1-t)*(1-t)*p0+2*(1-t)*t*p1+t*t*p2;
    }

    private void MoveLine(){
        Vector3 direction = p1.transform.position - p0.transform.position;
        direction.y = 0;
        direction.Normalize(); 
        p1.transform.position+=direction*lineMoveSpeed*Time.deltaTime;
        direction = p2.transform.position - p0.transform.position;
        direction.y = 0;
        direction.Normalize(); 
        p2.transform.position+=direction*Time.deltaTime;
        RedrawLine();
    }
    private void ResetPoints(){
        p0.transform.position = p0Init;
        p1.transform.position = p1Init;
        p2.transform.position = p2Init;
    }
    private void RedrawLine(){
        int counter = 0;
        float step = 1/(float)fishingLine.positionCount;
        fishingLine.positionCount = 0;
        for(float t = 0.0f; t-1.0<=epsilon;t+=step){
            fishingLine.positionCount = counter+1;
            Vector3 newPoint = BezierQuad(t, p0.transform.position, p1.transform.position, p2.transform.position);
            fishingLine.SetPosition(counter, newPoint);
            counter++;
        }
    }
}
