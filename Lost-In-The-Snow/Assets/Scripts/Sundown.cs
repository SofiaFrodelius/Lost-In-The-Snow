using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Sundown : MonoBehaviour
{
    public float switchToNightTime = 20;
    public float fastNightTime;
    public float slowNightTime;
    public Vector3 center;
    public bool lookAtCenter = true;
    public bool continuousOrbit;
    private float switchToNightDeg = 180;
    public float fastNightDeg = 0.0f;
    public float slowNightDeg = 0.0f;
    public GameObject moon;


    private float orbitSpeed = 0.0f;
    private float rotation = 0.0f;
    private float fastNightRotation;
    private float slowNightRotation;
    private bool daytime = true;
    private Vector3 axis = Vector3.right;

    public void Update()
    {

        if (continuousOrbit)
        {
            orbitSpeed = (360 / switchToNightTime) * Time.deltaTime;
            transform.RotateAround(center, axis, orbitSpeed);
        }

        else if (daytime)
        {
            orbitSpeed = (switchToNightDeg / switchToNightTime) * Time.deltaTime;
            transform.RotateAround(center, axis, orbitSpeed);
            rotation += orbitSpeed;
            Debug.Log(rotation);
            if (rotation > switchToNightDeg)
            {
                daytime = false;
            }
        }
        else if(fastNightRotation < fastNightDeg)
        {
            RenderSettings.sun = moon.GetComponent<Light>();
            orbitSpeed = (fastNightDeg / fastNightTime) * Time.deltaTime;
            moon.transform.RotateAround(center, axis, orbitSpeed);
            fastNightRotation += orbitSpeed;
        }
        else if(slowNightRotation < slowNightDeg)
        {
            orbitSpeed = (slowNightDeg / slowNightTime) * Time.deltaTime;
            moon.transform.RotateAround(center, axis, orbitSpeed);
            slowNightRotation += orbitSpeed;
        }
        if (lookAtCenter)
            transform.LookAt(center);
    }


    public void setOrbitTime(float time)
    {
        //orbitTime = time;
    }
}