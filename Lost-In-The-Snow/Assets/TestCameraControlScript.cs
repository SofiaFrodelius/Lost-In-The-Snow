using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestCameraControlScript : MonoBehaviour
{
    private GameObject cameraTarget;
    private bool cameraLock = false, cameraReturning = false;
    private Vector3 oldPosition;
    private Quaternion oldRotation;
    private int smoothTime = 0;

    public void LockCameraToObjectInstant(string tagToTarget)
    {
        cameraTarget = GameObject.FindGameObjectWithTag(tagToTarget);
        cameraLock = true;
    }

    public void LockCameraToObjectSmooth(string tagToTarget, int timeToLock)
    {
        smoothTime = timeToLock;
        cameraTarget = GameObject.FindGameObjectWithTag(tagToTarget);
        cameraLock = true;
    }

    public void UnlockCameraInstant()
    {
        cameraLock = false;
    }

    public void UnlockCameraSmooth(int timeToUnlock)
    {
        smoothTime = timeToUnlock;
        cameraReturning = true;
    }

    private void LateUpdate()
    {
        if (cameraReturning)
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
