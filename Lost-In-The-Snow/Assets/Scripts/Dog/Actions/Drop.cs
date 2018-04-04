using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Drop : DogAction {
	Transform target;
	public override void OnActionStart(){
        if(dog.ItemObject != null){
            dog.ItemObject.GetComponent<Rigidbody>().isKinematic = false;
            dog.ItemObject.transform.parent = null;
        }
        dog.ItemObject = null;
        dog.GrabbedItem = null;
		animator.SetTrigger ("ActionDone");
	}
	public override void OnActionUpdate(){
	}
	public override void OnActionEnd(){
	}
}
