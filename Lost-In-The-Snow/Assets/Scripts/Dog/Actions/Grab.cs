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
		//dog.GrabbedObject = handler.Grab (dog.gameObject);
	}
}
