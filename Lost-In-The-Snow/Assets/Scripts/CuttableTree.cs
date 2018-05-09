using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableTree : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log("Interacted with tree");
        GameObject playerObj = GameObject.FindWithTag("Player");
        CharacterMovement charMove = null;
        if (playerObj != null)
            charMove = playerObj.GetComponent<CharacterMovement>();
        if (charMove != null)
        {
            float hAngle = 3;
            Vector2 targetLook = new Vector2(hAngle, 0f);
            charMove.ForceMovement(charMove.transform.position, targetLook);
        }
    }
}