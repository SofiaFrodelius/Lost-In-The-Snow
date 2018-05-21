using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableTree : MonoBehaviour, IInteractible
{
    private int hitPoints = 3;
    private bool activated = false;
    private GameObject playerObj;
    private CharacterMovement charMove = null;
    GameObject activeItem = null;
    [SerializeField] private GameObject firewood;

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
                    hAngle += 2;
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
                    GrabableObject grabableObject = activeItem.GetComponent<GrabableObject>();
                    if (grabableObject != null)
                    {
                        //if (animation finished)
                        //{
                        activated = false;
                        charMove.CutsceneRelease();
                        hitPoints--;
                        if (hitPoints <= 0)
                        {
                            // Tree dying stuff goes here
                            for (int i = 0; i < 15; i++)
                            {
                                Instantiate(firewood, transform.position + new Vector3(0, 0.2f + (0.4f * i), 0), Quaternion.LookRotation(Vector3.up));
                            }
                            gameObject.SetActive(false);
                        }
                        //}
                    }
                    else
                    {
                        Debug.Log("axeSwing is null");

                    }
                }
            }
            else Debug.Log("charMove is null");
        }
    }
}