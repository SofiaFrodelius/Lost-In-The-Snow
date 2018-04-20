using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private float timeUntilNight = 5.0f;
    private float targetBlend = 1.0f;

    [SerializeField]
    private AnimationCurve skyboxBlendCurve;
    [SerializeField]
    private AnimationCurve sunIntensityCurve;
    [SerializeField]
    [Range(-10, 60)]
    private float sunTarget = 0.0f;
    private float sunDelta = 0.0f;
    private float currentSunMove = 0.0f;


    private float blend = 0;
    private float defaultBlend = 0;
    private float currentFrameTime = 0;
    private Animator anim;


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
        sunDelta = sunTarget - transform.GetChild(0).transform.localEulerAngles.x;
    }


    public void Update()
    {
        if (anim.GetBool("Sundown") && RenderSettings.skybox.GetFloat("_Blend") < targetBlend)
        {
            currentFrameTime = (1 / timeUntilNight) * Time.deltaTime; //1 because _Blend max value is 1 and min value is 0
            currentSunMove = (sunDelta / timeUntilNight) * Time.deltaTime;

            transform.GetChild(0).transform.Rotate(Vector3.right, currentSunMove); //rotate sun
            blend += currentFrameTime;
            RenderSettings.sun.intensity = sunIntensityCurve.Evaluate(blend);
            RenderSettings.skybox.SetFloat("_Blend", skyboxBlendCurve.Evaluate(blend));
            RenderSettings.ambientSkyColor = skyColor;
            RenderSettings.ambientEquatorColor = equatorColor;
            RenderSettings.ambientGroundColor = groundColor;
        }
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