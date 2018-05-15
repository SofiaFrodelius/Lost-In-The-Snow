using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableTree : MonoBehaviour, IInteractible
{
    private int hitPoints = 5;
    private bool activated = false;
    private GameObject playerObj;
    private CharacterMovement charMove = null;
    GameObject activeItem = null;

    public void AlternateInteract()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            charMove = playerObj.GetComponent<CharacterMovement>();
        if (charMove != null)
        {
            ItemHand itemHand = Camera.main.GetComponentInChildren<ItemHand>();
            if (itemHand != null)
                activeItem = itemHand.ActiveItem;
            if (activeItem != null)
            {
                if (activeItem.tag == "Axe")
                {
                    activated = true;
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
                        cuttingposition.z * cuttingDistance), targetLook, false);
                }
            }
        }
    }

    private void Update()
    {
        if (activated)
        {
            if (charMove != null)
            {
                if (!charMove.GetForcedMove())
                {
                    // Play Animation here
                    Debug.Log("Tree chopping animation");
                    AxeSwing axeSwing = activeItem.GetComponent<AxeSwing>();
                    if (axeSwing != null)
                    {
                        axeSwing.Use(Camera.main.GetComponentInChildren<ItemHand>());
                        // if (animation finished)
                        //{
                        activated = false;
                        charMove.CutsceneRelease();
                        hitPoints--;
                        if (hitPoints <= 0)
                        {
                            Debug.Log("DING DONG, the tree is dead!");
                        }
                        //}
                    }
                }
            }
        }
    }
}