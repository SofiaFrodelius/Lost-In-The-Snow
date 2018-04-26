using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private Light sun,moon;

    [SerializeField]
    private float timeUntilNight = 5.0f;
    private float targetBlend = 1.0f;
    [SerializeField]
    private AnimationCurve skyboxBlendCurve;
    [SerializeField]
    private AnimationCurve sunIntensityCurve;
    [SerializeField]
    private AnimationCurve moonIntensityCurve;

    [SerializeField]
    [Range(-10, 60)]
    private float sunTarget = 0.0f;
    private float rotationDelta = 0.0f;
    private float currentMove = 0.0f;


    private float blend = 0;
    private float defaultBlend = 0;
    private float currentFrameTime = 0;
    private Animator anim;
    private bool nightTime = false;


    [HideInInspector]
    public Color skyColor, equatorColor, groundColor;


    public void Start()
    {
        defaultBlend = RenderSettings.skybox.GetFloat("_Blend");
        skyColor = RenderSettings.ambientSkyColor;
        equatorColor = RenderSettings.ambientEquatorColor;
        groundColor = RenderSettings.ambientGroundColor;
        anim = GetComponent<Animator>();
        anim.speed = 1 / timeUntilNight;
        rotationDelta = sunTarget - sun.transform.localEulerAngles.x;
    }


    public void Update()
    {
        if (anim.GetBool("Sundown") && RenderSettings.skybox.GetFloat("_Blend") < targetBlend/2)
        {
            updateBlend();
            rotate(sun.gameObject);
            sun.intensity = sunIntensityCurve.Evaluate(blend);
            setColors();
            nightTime = true;
        }

        else if(nightTime && RenderSettings.skybox.GetFloat("_Blend") < targetBlend)
        {
            updateBlend();
            rotate(moon.gameObject);
            moon.intensity = moonIntensityCurve.Evaluate(blend);
            setColors();

        }
    }


    private void rotate(GameObject go)
    {
        currentMove = (rotationDelta / (timeUntilNight)) * Time.deltaTime;
        currentMove *= 2;
        go.transform.Rotate(Vector3.right, currentMove);
    }

    private void updateBlend()
    {
        currentFrameTime = (1 / (timeUntilNight)) * Time.deltaTime; //1 because _Blend max value is 1 and min value is 0
        blend += currentFrameTime;
        RenderSettings.skybox.SetFloat("_Blend", skyboxBlendCurve.Evaluate(blend));
    }

    private void setColors()
    {
        RenderSettings.ambientSkyColor = skyColor;
        RenderSettings.ambientEquatorColor = equatorColor;
        RenderSettings.ambientGroundColor = groundColor;
    }


    //temp
    public void OnApplicationQuit()
    {
        RenderSettings.skybox.SetFloat("_Blend", defaultBlend);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggerSundown();
        }
    }

    public void triggerSundown()
    {
        anim.SetBool("Sundown", true);
    }
}