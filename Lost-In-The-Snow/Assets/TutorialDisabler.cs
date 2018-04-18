using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialDisabler : MonoBehaviour
{
    public float maxInteractLength = 4f;
    public LayerMask interactLayerMask;

    private void Update()
    {
        //change keycode.e to "input/interact" later
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward);

            
            if (Physics.Raycast(ray, out hit, maxInteractLength, interactLayerMask))
            {
                Debug.Log("Hit: " + hit.transform.name);
                ExecuteEvents.ExecuteHierarchy<ITutorialInteractable>(hit.transform.gameObject, null, (handler, eventData) => handler.onTutorialFinish());
            }
        }
    }
}
