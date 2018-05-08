using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, IInteractible
{
    public bool isChoppable = false;

    public void Interact()
    {
        Debug.Log("Interacted with tree");
    }
}