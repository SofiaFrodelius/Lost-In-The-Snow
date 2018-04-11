using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestCameraControlScript : MonoBehaviour
{
    private GameObject cameraTarget;
    private bool cameraLock = false, cameraSmoothing = false;
    private Vector3 oldPosition;
    private Quaternion oldRotation;
    private int smoothTime = 0;
    private float t = 0.0f;

    public void LockCameraToObjectInstant(string tagToTarget)
    {
        cameraTarget = GameObject.FindGameObjectWithTag(tagToTarget);
        cameraLock = true;
        cameraSmoothing = false;
    }

    public void LockCameraToObjectSmooth(string tagToTarget, int timeToLock)
    {
        smoothTime = timeToLock;
        cameraTarget = GameObject.FindGameObjectWithTag(tagToTarget);
        cameraLock = true;
        cameraSmoothing = true;
    }

    public void UnlockCameraInstant()
    {
        cameraSmoothing = false;
        cameraLock = false;
    }

    public void UnlockCameraSmooth(int timeToUnlock)
    {
        smoothTime = timeToUnlock;
        cameraSmoothing = true;
        cameraLock = false;
    }

    private void LateUpdate()
    {
        if (cameraSmoothing)
        {
            
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
