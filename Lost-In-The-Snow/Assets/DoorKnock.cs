using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnock : MonoBehaviour, IInteractible
{
    bool hasKnocked = false;
    bool knockPrompt = true;
    [SerializeField]
    private int doorKnockId = 0;


    public void AlternateInteract()
    {
        if (!hasKnocked)
        {
            Debug.Log("knackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknackknack");
            hasKnocked = true;
        }
        if(hasKnocked && knockPrompt)
        {
            knockPrompt = false;
            InteractPrompt ip;
            ip = transform.GetComponent<InteractPrompt>();
            ip.promptToggleSpecific(false, doorKnockId);
            ip.removePrompt(doorKnockId);
        }
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
