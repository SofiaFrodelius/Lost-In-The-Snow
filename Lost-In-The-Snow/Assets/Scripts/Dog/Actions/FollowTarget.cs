using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : DogAction {
	Transform target;
	public override void OnActionStart(){
		target = dog.Target;
		navAgent.SetDestination(target.position);
		animator.SetBool ("isAtTarget", false);
	}
	public override void OnActionUpdate(){
		if(target.position != navAgent.destination)
			navAgent.SetDestination(target.position);
		if (Vector3.Distance (dog.transform.position, target.position) < 1.2f) {
			navAgent.ResetPath ();
			animator.SetBool ("isAtTarget", true);
		}
	}
	public override void OnActionEnd(){
		navAgent.ResetPath ();
	}
}
