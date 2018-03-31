using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : DogAction {
	public override void OnActionStart(){
		//target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
	public override void OnActionUpdate(){
		//navAgent.SetDestination (target.position +target.forward);
	}
	public override void OnActionEnd(){
		navAgent.ResetPath ();
	}
}
