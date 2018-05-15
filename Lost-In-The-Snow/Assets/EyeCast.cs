﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    [SerializeField] private ChracterInteract ci;
    private float interactLength;
    private RaycastHit hit;
    private InteractPrompt ip;
    private InteractPrompt current;

    private void Start()
    {
        if (ci)
        {
            interactLength = ci.MaxInteractLength;
            StartCoroutine(cast());
        }

        else Debug.LogWarning("variable ci not assigned");

    }



    IEnumerator cast()
    {
        while(true)
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, interactLength))
            {
                ip = hit.transform.GetComponent<InteractPrompt>();
                if (ip != null && ip != current)
                {
                    if(current && current != ip)
                    {
                        current.promptToggle(false);
                    }

                    ip.promptToggle(true);
                    current = ip;
                }
                else if(ip == null && current)
                {
                    current.promptToggle(false);
                    current = null;
                }
             }
            else if (current)
            {
                current.promptToggle(false);
                current = null;
            }
            yield return new WaitForSeconds(0.15f);
        }
    }

    private void enablePrompts()
    {
        current.promptToggle(true);
    }


    private void disablePrompts()
    {

    }



}
