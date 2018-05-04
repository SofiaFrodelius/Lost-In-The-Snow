//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//[RequireComponent(typeof(Rigidbody))]
//public class ThrowableItem : MonoBehaviour, IUsable {
//    Rigidbody rb;
//	[SerializeField]private float throwForce = 20f;
//    Inventory inventory;
//	void Awake(){
//		rb = GetComponent<Rigidbody> ();
//	}

//    public void Start(){
//        inventory = Inventory.instance;
//    }


//    public void Use(ItemHand ih){
//        Vector3 throwDirection = Camera.main.transform.forward;
//		rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
//        rb.AddRelativeTorque((Vector3.left + Vector3.up) * 10);
//        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
//        transform.parent = null;
//        inventory.removeHoldableItem(ih.getSelectedItem());
//        //ih.ActiveItem = null;
//    }
//    void OnCollisionEnter(Collision collision){
//		Debug.Log (name + " hit something");
//        //Debug.Log("ColliderHit, Ha sönder snöboll och spawna partiklar");
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ThrowableItem : MonoBehaviour, IUsable
{
    Rigidbody rb;
    Inventory inventory;
    [SerializeField] private float throwForce = 20f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        inventory = Inventory.instance;
    }

    public void Use(ItemHand ih)
    {
        //Debug.Log(ih.ActiveItem);
        Vector3 throwDirection = Camera.main.transform.forward;
        rb.isKinematic = false;
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        rb.AddRelativeTorque((Vector3.down) * 10);
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        transform.parent = null;
        inventory.removeHoldableItem(ih.getSelectedItem());
        //ih.ActiveItem = null;
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ColliderHit, Ha sönder snöboll och spawna partiklar");
    }
}

