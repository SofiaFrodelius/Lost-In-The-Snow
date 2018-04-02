using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorra : MonoBehaviour, IInteractible {
    [SerializeField] private Vector3 rotateAmount;
    [SerializeField] private float openSpeed;
    private Vector3 StartRotation;

    private bool isOpen = false;

    public void Interact()
    {
        Debug.Log("Hora");
        ToggleDoor();
    }
    void ToggleDoor()
    {

        //Detta ska ske i animation
        if (isOpen)
            transform.Rotate(rotateAmount);
        else
            transform.Rotate(StartRotation);

        isOpen = !isOpen;
    }
}
