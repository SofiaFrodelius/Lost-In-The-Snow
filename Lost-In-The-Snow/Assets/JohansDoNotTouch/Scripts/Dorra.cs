using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorra : MonoBehaviour, IInteractible {
    private Vector3 StartRotation;

    public void Interact()
    {
        //Debug.Log("Door");
        //Play door sound
        //
        SceneHandler.ChangeScene(0);
        
        //ToggleDoor();
    }
}
