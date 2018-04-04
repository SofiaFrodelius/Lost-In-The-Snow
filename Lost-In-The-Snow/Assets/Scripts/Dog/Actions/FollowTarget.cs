using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : DogAction {
	Transform target;
    Vector3 offset;
	public override void OnActionStart(){
		target = dog.Target;
        offset = target.forward;
		navAgent.SetDestination(target.position+ offset);
		animator.SetBool ("isAtTarget", false);
	}
	public override void OnActionUpdate(){
        if (!animator.GetBool("isAtTarget")){
            offset = target.forward;
            if (target.position + offset != navAgent.destination)
                navAgent.SetDestination(target.position + offset);
        }
        if (target != null && Vector3.Distance(dog.transform.position, target.position + offset) < 1.2f){
            navAgent.ResetPath();
            animator.SetBool("isAtTarget", true);
        }
    }
	public override void OnActionEnd(){
		navAgent.ResetPath ();
	}
}
