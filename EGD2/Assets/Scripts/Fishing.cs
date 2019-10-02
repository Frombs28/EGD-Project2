using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public bool isFishing = false;
    private bool fishOnLine = false;
    [SerializeField]
    [Range(0,1)]
    private float fishingChance = .05f;
    [SerializeField]
    private float timeBetweenCheck = .1f;
    private LineRenderer fishingLine;
    [SerializeField]
    private GameObject fishyPrefab = null;
    [SerializeField]
    private GameObject p0;
    [SerializeField]
    private GameObject p1;
    [SerializeField]
    private GameObject p2;
    private float epsilon = .001f;
    Vector3 p0Init, p1Init, p2Init;
    [SerializeField]
    private float lineMoveSpeed = 1f;
    [SerializeField]
    private float lineCastTime = 2f;
    private float startTime = 0.0f;
    [SerializeField]
    private int drawInToCastRatio = 2;
    [SerializeField]
    private float maxLineDistance = 100f;
    [SerializeField]
    private int fastestFish = 10;
    [SerializeField]
    private int slowestFish = 5;
    private int fishSpeed = 0;
    GameObject fishy;
    Move player;
    private List<GameObject> fishStack;
    [SerializeField]
    private GameObject fishStackLocation;
    // Start is called before the first frame update
    void Start()
    {
        fishStack = new List<GameObject>();
        fishingLine = GetComponent<LineRenderer>();
        fishingLine.positionCount = 0;
        p0Init = p0.transform.position;
        p1Init = p1.transform.position;
        p2Init = p2.transform.position;
        fishyPrefab.SetActive(false);
        player = FindObjectOfType<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFishing){
            MoveLine();
            TryCatch();
            if(Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Akshdfkjshdf");
                PlayerDrawsIn();
            }
        } 
    }

    public void StartFishing(){
        //throw out line here
        fishOnLine = false;
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
    }

    public void PlayerDrawsIn(){
        StartCoroutine(DrawLineIn(drawInToCastRatio,fishOnLine));
    }

    private IEnumerator DrawLineIn(int stepRatio, bool isFishCaught = false){
        int counter = fishingLine.positionCount;
        float step = stepRatio/(float)fishingLine.positionCount;
        isFishing = false;
        Debug.Log("Step is: "+ step);
        if(isFishCaught){
            fishy = Instantiate(fishyPrefab, fishyPrefab.transform.position, Quaternion.identity);
            fishy.transform.Rotate(0,180,0);
            fishy.SetActive(true);
        }
        for(float t = 1.0f; t-0.0f>=epsilon;t-=step){
            if(counter<=0){
                fishingLine.positionCount = 0;
                break;
            }
            fishingLine.positionCount = counter;
            Vector3 newPoint = BezierQuad(t, p0.transform.position, p1.transform.position, p2.transform.position);
            if(isFishCaught){
                fishy.transform.position = newPoint;
            }  
            counter-=stepRatio;
            yield return null;
            fishingLine.SetPosition(counter-1, newPoint);
        }
        fishingLine.positionCount = 0;
        if(isFishCaught){
            //fishyRb.useGravity = true;
            //To Do: have fishy stay/flop for 2 seconds and then set active to false
            TeleportFish(fishy);
        }
        ResetPoints();
        if(player!=null) player.UnlockPlayer();
    }

    private Vector3 BezierQuad(float t, Vector3 p0, Vector3 p1, Vector3 p2){
        return (1-t)*(1-t)*p0+2*(1-t)*t*p1+t*t*p2;
    }

    private void MoveLine(){
        if(Vector3.Distance(p2.transform.position, p0.transform.position)>maxLineDistance){
            SnapLine();
            return;
        }
        Vector3 direction = p1.transform.position - p0.transform.position;
        direction.y = 0;
        direction.Normalize();
        if(fishOnLine){
            //maybe have something more dramatic than just speeding up when a fish is on line
            direction*=fishSpeed;
        } 
        p1.transform.position+=direction*lineMoveSpeed*Time.deltaTime;
        direction = p2.transform.position - p0.transform.position;
        direction.y = 0;
        direction.Normalize(); 
        if(fishOnLine){
            direction*=fishSpeed;
        } 
        p2.transform.position+=direction*Time.deltaTime*lineMoveSpeed;
        RedrawLine();
        //Debug.Log(Vector3.Angle(p1.transform.position, p0.transform.position));
    }

    private void TryCatch(){
        if(!fishOnLine){
            float fishCaught = Random.value;
            if(fishingChance>fishCaught){
                Debug.Log("caught fish!!");
                fishOnLine = true;
                fishSpeed = Random.Range(slowestFish, fastestFish);
            }
        }
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

    private void SnapLine(){
        int ratio = 5*drawInToCastRatio;
        StartCoroutine(DrawLineIn(ratio));
        //fishingLine.positionCount = 0;
        isFishing = false;
    }
    void TeleportFish(GameObject fish){
        Vector3 fishLoc = fishStackLocation.transform.position;
        fishLoc.y += fishStack.Count*fish.GetComponent<BoxCollider>().size.y;
        fish.transform.position = fishLoc;
        fishStack.Add(fish);
    }

    public void ClearFishStack(){
        foreach (var fish in fishStack)
        {
            Destroy(fish);
        }
        fishStack.Clear();
    }
}
