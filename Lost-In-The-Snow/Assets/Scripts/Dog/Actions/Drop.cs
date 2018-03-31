using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Drop : DogAction {
	Transform target;
	public override void OnActionStart(){
		ExecuteEvents.Execute<IGrabable> (dog.GrabbedObject, null, HandleEvent);
		animator.SetTrigger ("ActionDone");
	}
	public override void OnActionUpdate(){
	}
	public override void OnActionEnd(){
	}
	private void HandleEvent(IGrabable handler, BaseEventData eventData){
		handler.Drop ();
	}
}
