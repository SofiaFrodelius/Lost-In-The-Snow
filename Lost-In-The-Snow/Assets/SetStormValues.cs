using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStormValues : MonoBehaviour
{
    [SerializeField] private ParticleSystem storm;
    [SerializeField] private float startLifeTime = 3;
    [SerializeField] private float rateOverTime = 300;
    [SerializeField] private Vector3 forceOverTime = new Vector3(10, 0, 10);
    [SerializeField] private float time = 5.0f;

    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.EmissionModule stormEmission;
    private ParticleSystem.ForceOverLifetimeModule forceOverLifeTimeModule;




    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            mainModule = storm.main;
            stormEmission = storm.emission;
            forceOverLifeTimeModule = storm.forceOverLifetime;


            mainModule.startLifetime = startLifeTime;
            stormEmission.rateOverTime = rateOverTime;
            forceOverLifeTimeModule.x = forceOverTime.x;
            forceOverLifeTimeModule.y = forceOverTime.y;
            forceOverLifeTimeModule.z = forceOverTime.z;
          //StartCoroutine(setStorm());
        }
    }

    //IEnumerator setStorm()
    //{
    //    float elapsedTime = 0.0f;
    //    ParticleSystem.MinMaxCurve startStartLifeTime = mainModule.startLifetime;
    //    ParticleSystem.MinMaxCurve startRateOverTime = stormEmission.rateOverTime;
    //    ParticleSystem.MinMaxCurve startForceOverTimeX = forceOverLifeTimeModule.x;
    //    ParticleSystem.MinMaxCurve startForceOverTimeY = forceOverLifeTimeModule.y;
    //    ParticleSystem.MinMaxCurve startForceOverTimeZ = forceOverLifeTimeModule.z;

    //    while (elapsedTime < time)
    //    {
    //        mainModule.startLifetime = Mathf.Lerp(startStartLifeTime.constant, startLifeTime, (elapsedTime / time));
    //        stormEmission.rateOverTime = Mathf.Lerp(startRateOverTime.constant, rateOverTime, (elapsedTime / time));
    //        Debug.Log(mainModule.startLifetime);
    //        yield return null;
    //    }
    //}


}
