using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GotoTarget : DogAction {
	Vector3 target;
	public override void OnActionStart(){
		target = dog.Target.position;
		navAgent.SetDestination(target);
		animator.SetBool ("isAtTarget", false);
	}
	public override void OnActionUpdate(){
		if (Vector3.Distance (dog.transform.position, target) < 1.5f) {
			navAgent.ResetPath ();
			animator.SetBool ("isAtTarget", true);
		}
	}
	public override void OnActionEnd(){
		navAgent.ResetPath ();
	}
}
