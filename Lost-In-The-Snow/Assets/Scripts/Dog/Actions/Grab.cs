using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Grab : DogAction {
	Transform target;
	public override void OnActionStart(){
		target = dog.Target;
		ExecuteEvents.Execute<IGrabable> (target.gameObject, null, HandleEvent);
		dog.Target = dog.Player;
		animator.SetTrigger ("ActionDone");
	}
	public override void OnActionUpdate(){
	}
	public override void OnActionEnd(){
	}
	private void HandleEvent(IGrabable handler, BaseEventData eventData){
        Item temp;
        handler.pickUp(out temp);
        dog.GrabbedItem = temp;
        dog.ItemObject = Instantiate(dog.GrabbedItem.getAssociatedGameobject(), dog.bone)as GameObject;
        dog.ItemObject.GetComponent<Rigidbody>().isKinematic = true;
        dog.ItemObject.transform.localPosition = Vector3.zero;
        dog.ItemObject.transform.localRotation = Quaternion.identity;
    }
}
