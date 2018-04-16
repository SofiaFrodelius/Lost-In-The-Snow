using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraShake : MonoBehaviour {
    [Tooltip("Shake Intensity Over Time")]
    [SerializeField] private AnimationCurve shakeIntencity;
    [Tooltip("Shake Intensity Over Time")]
    [SerializeField] private float shakeDuration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraShake cs = other.GetComponentInChildren<CameraShake>();
            if (cs == null)
            {
                Debug.LogWarning("Camera Shake Script missing on Player");
                return;
            }
            cs.ToggleShake(shakeIntencity, shakeDuration);


        }
    }
}
