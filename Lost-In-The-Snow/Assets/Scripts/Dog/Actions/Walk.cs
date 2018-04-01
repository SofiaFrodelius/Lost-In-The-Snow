using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : DogAction {
	Vector3 target;
	public override void OnActionStart(){
		target = GetRandomTarget ();
		navAgent.SetDestination(target);
	}
	public override void OnActionUpdate(){
		dog.GrabbedObject.transform.position = target;
		if (Vector3.Distance (dog.transform.position, target) < 1.5f) {
			navAgent.ResetPath ();
			target = GetRandomTarget ();
			navAgent.SetDestination (target);
		}
	}
	public override void OnActionEnd(){
		navAgent.ResetPath ();
	}

	Vector3 GetRandomTarget(){
		Debug.DrawRay (dog.transform.position, dog.Player.forward * 4f, Color.blue, 5f);
		Debug.DrawRay (dog.transform.position, dog.Player.right * 4f, Color.green, 5f);
		Vector3 fora = dog.Player.forward * Random.Range (4f, 20f);
		fora += dog.Player.right * Random.Range (-5f, 5f);
		return fora;
	}
}
