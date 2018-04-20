using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractible
{
    [SerializeField]
    private SceneSwitchScript swc;
    public void Interact()
    {
        swc.ActivateSceneSwitch(1);
    }
}
