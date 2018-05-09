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
            float hAngle;
            Vector2 deltaVector = new Vector2(transform.position.x - charMove.transform.position.x, transform.position.z - charMove.transform.position.z);
            //hAngle = Vector2.Angle(new Vector2(transform.position.x, transform.position.z), new Vector2(charMove.transform.position.x, charMove.transform.position.z));
            hAngle = Vector2.SignedAngle(Vector2.up, deltaVector.normalized);
            Debug.Log(deltaVector);
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