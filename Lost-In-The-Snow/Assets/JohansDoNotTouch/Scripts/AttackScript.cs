using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackScript : MonoBehaviour {
    [SerializeField] private float maxInteractLength = 2f;



    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Klicka Knapp");
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward);
            if(Physics.Raycast(ray, out hit, maxInteractLength))
            {

                ExecuteEvents.ExecuteHierarchy<IAttackeble>(hit.transform.gameObject, null, (handler, eventData) => handler.onAttack());
            }
        }
	}
    
}
