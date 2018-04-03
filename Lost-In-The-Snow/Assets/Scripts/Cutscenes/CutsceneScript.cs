using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public List<GameObject> nodeList;
    public Camera relevantCamera;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private int nodeIterator = 1;
    private int nodeTime = 0, nodePause = 0;
    private float t = 0.0f;
    private bool finished = false;

    private void Start()
    {
        startPosition = relevantCamera.transform.position;
        startRotation = relevantCamera.transform.rotation;
        relevantCamera.transform.position = nodeList[0].transform.position;
        relevantCamera.transform.rotation = nodeList[0].transform.rotation;

        if (nodeList.Count > 1)
        {
            CutsceneNodeScript nodeScript;
            nodeScript = (CutsceneNodeScript)nodeList[1].GetComponent("CutsceneNodeScript");
            nodeTime = nodeScript.movementTime;
            nodePause = nodeScript.pauseTime;
        }
        else
            finished = true;
    }

    private void LateUpdate()
    {
        for (int i = 1; i < nodeList.Count; i++)
        {
            Debug.DrawLine(nodeList[i - 1].transform.position, nodeList[i].transform.position, Color.red);
        }

        if (!finished)
        {
            relevantCamera.transform.position = new Vector3(Mathf.Lerp(nodeList[nodeIterator - 1].transform.position.x, nodeList[nodeIterator].transform.position.x, t),
              Mathf.Lerp(nodeList[nodeIterator - 1].transform.position.y, nodeList[nodeIterator].transform.position.y, t),
              Mathf.Lerp(nodeList[nodeIterator - 1].transform.position.z, nodeList[nodeIterator].transform.position.z, t));

            relevantCamera.transform.rotation = new Quaternion(Mathf.Lerp(nodeList[nodeIterator - 1].transform.rotation.x, nodeList[nodeIterator].transform.rotation.x, t),
                Mathf.Lerp(nodeList[nodeIterator - 1].transform.rotation.y, nodeList[nodeIterator].transform.rotation.y, t),
                Mathf.Lerp(nodeList[nodeIterator - 1].transform.rotation.z, nodeList[nodeIterator].transform.rotation.z, t),
                Mathf.Lerp(nodeList[nodeIterator - 1].transform.rotation.w, nodeList[nodeIterator].transform.rotation.w, t));

            t += Time.deltaTime * 1000 / nodeTime;

            if (t > 1.0f)
            {
                t = 0.0f;
                nodeIterator++;
                if (nodeIterator < nodeList.Count)
                {
                    CutsceneNodeScript nodeScript;
                    nodeScript = (CutsceneNodeScript)nodeList[nodeIterator].GetComponent("CutsceneNodeScript");
                    nodeTime = nodeScript.movementTime;
                    nodePause = nodeScript.pauseTime;
                }
                else
                {
                    finished = true;
                    relevantCamera.transform.position = startPosition;
                    relevantCamera.transform.rotation = startRotation;
                }
            }
        }
    }
}