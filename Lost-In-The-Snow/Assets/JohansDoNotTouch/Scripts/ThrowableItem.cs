using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : MonoBehaviour, IUsable {
    Rigidbody rb;
     
    public void Use(ItemHand ih)
    {
        Vector3 throwDirection = Camera.main.transform.forward;
        rb = gameObject.AddComponent<Rigidbody>();
        rb.AddForce(throwDirection * 20, ForceMode.Impulse);
        rb.AddRelativeTorque((Vector3.left + Vector3.up) * 10);
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        transform.parent = null;
        ih.ActiveItem = null;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ColliderHit, Ha sönder snöboll och spawna partiklar");
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
    }
}
