using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Feed : DogAction {
	public override void OnActionStart(){
		dog.GrabbedObject = null;
	}
	public override void OnActionUpdate(){
	}
	public override void OnActionEnd(){
	}
}
