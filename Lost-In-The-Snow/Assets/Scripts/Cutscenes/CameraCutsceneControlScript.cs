using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraCutsceneControlScript : MonoBehaviour
{
    private GameObject cameraTarget;
    private bool cameraLock = false, cameraSmoothing = false;
    private Vector3 oldPosition;
    private Quaternion oldRotation;
    private float smoothSpeed = 0.0f;
    private float t = 0.0f;

    public void LockCameraToObjectInstant(string tagToTarget)
    {
        cameraTarget = GameObject.FindGameObjectWithTag(tagToTarget);
        cameraLock = true;
        cameraSmoothing = false;
    }

    public void LockCameraToObjectSmooth(string tagToTarget, float smoothingSpeed)
    {
        smoothSpeed = smoothingSpeed;
        cameraTarget = GameObject.FindGameObjectWithTag(tagToTarget);
        cameraLock = true;
        cameraSmoothing = true;
    }

    public void UnlockCameraInstant()
    {
        cameraSmoothing = false;
        cameraLock = false;
    }

    public void UnlockCameraSmooth(float smoothingSpeed)
    {
        smoothSpeed = smoothingSpeed;
        cameraSmoothing = true;
        cameraLock = false;
    }

    private void LateUpdate()
    {
        Vector3 vectorToTarget = new Vector3(0, 0, 0);
        if (cameraTarget != null)
        {
            vectorToTarget = cameraTarget.transform.position - transform.position;
        }
        if (cameraSmoothing)
        {
            Vector2 animationRotation = new Vector2(transform.rotation.x, transform.rotation.y);
            if (cameraLock)
            {

            }
            else
            {
                
            }
        }
        else if (cameraLock)
        {
            if (cameraTarget != null)
            {
                Camera.main.transform.LookAt(cameraTarget.transform);
            }
        }
    }
}
