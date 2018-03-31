using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogAction : StateMachineBehaviour {
	protected Dog dog;
	protected NavMeshAgent navAgent;
	protected Animator animator;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		dog = animator.gameObject.GetComponent<Dog> ();
		navAgent = dog.gameObject.GetComponent<NavMeshAgent> ();
		this.animator = animator;
		OnActionStart ();
	}
	public virtual void OnActionStart(){}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		OnActionUpdate ();
	}
	public virtual void OnActionUpdate(){}

	public override void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		OnActionEnd ();
	}
	public virtual void OnActionEnd(){}
}
