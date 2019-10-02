using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour
{

    public Light sun;
    public Light moon;
    public GameObject stars;
    public GameObject player;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;
    private float currentTime;
    public float timeToLerp = 5f;
    private bool day = true;

    private Transform[] starTransforms;
    private Renderer[] starMats;

    private Color transparent;

    float sunInitialIntensity;

    void Start()
    {
        transparent = new Color(1, 1, 1, 0);
        sunInitialIntensity = sun.intensity;

        starTransforms = stars.GetComponentsInChildren<Transform>();
        starMats = stars.GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        UpdateSun();
        UpdateMoon();
        UpdateStars();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateStars()
    {
        //print(day);

        print(starMats.Length);
        print(starTransforms.Length);

        //fade in stars on nighttime
        if (currentTimeOfDay < .25f || currentTimeOfDay > .75f)
        {
            if (!day)
            {
                day = true;
                StartCoroutine(FadeTo(starMats[0], 1, 5f));
            }
        }
        else
        {
            if (day)
            {
                day = false;
                StartCoroutine(FadeTo(starMats[0], 0, 5f));
            }
        }

        for (int i = 0; i < starTransforms.Length - 1; i++)
        {
            //make stars follow player
            starTransforms[i + 1].position = Vector3.Lerp(starTransforms[i + 1].position, new Vector3(player.transform.position.x, 
                starTransforms[i + 1].position.y, player.transform.position.z), 0.1f);

            starMats[i].material.color = starMats[0].material.color;
        }
    }

    void UpdateMoon()
    {
        moon.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 270, 170, 0);
        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.25f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0.1f;
        }
        else
        {
            intensityMultiplier = 0;
        }

        moon.intensity = sunInitialIntensity * intensityMultiplier;
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier/2;
    }

    IEnumerator FadeTo(Renderer obj, float aValue, float aTime)
    {
        float alpha = obj.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            //print(newColor);
            obj.material.color = newColor;
            yield return null;
        }
    }
}