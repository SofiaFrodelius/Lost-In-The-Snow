using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableTree : MonoBehaviour, IInteractible
{
    private bool activated = false;

    public void Interact()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        CharacterMovement charMove = null;
        if (playerObj != null)
            charMove = playerObj.GetComponent<CharacterMovement>();
        if (charMove != null)
        {
            ItemHand itemHand = Camera.main.GetComponentInChildren<ItemHand>();
            GameObject activeItem = null;
            if (itemHand != null)
                activeItem = itemHand.ActiveItem;
            if (activeItem != null)
            {
                if (activeItem.tag == "Axe")
                {
                    float hAngle;
                    Vector2 deltaVector = new Vector2(transform.position.x - playerObj.transform.position.x, transform.position.z - playerObj.transform.position.z);
                    hAngle = Mathf.Atan2(deltaVector.x, deltaVector.y);
                    hAngle *= 360;
                    hAngle /= Mathf.PI * 2;
                    hAngle += 3;
                    while (hAngle < 0)
                        hAngle += 360;
                    while (hAngle >= 360)
                        hAngle -= 360;
                    Vector2 targetLook = new Vector2(hAngle, 0f);
                    Vector3 cuttingposition = new Vector3(-deltaVector.x, 0, -deltaVector.y);
                    cuttingposition.Normalize();
                    float cuttingDistance = 2;
                    charMove.ForceMovement(transform.position + new Vector3(cuttingposition.x * cuttingDistance, charMove.transform.position.y - transform.position.y,
                        cuttingposition.z * cuttingDistance), targetLook);
                }
            }
        }
    }
}