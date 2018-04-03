using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour, IInteractible {
	public Transform player;
	public Transform target;
	public GameObject grabbedObject;

	public Transform TESTBONE;

	private Animator animator;
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	void Start () {
		target = TESTBONE;
		animator.SetTrigger ("Fetch");
	}
	void Update(){
		if (Input.GetKey (KeyCode.Q)) {
        }
	}
	public void Interact(){
		//animator.SetTrigger ("Pet");
		//animator.SetTrigger("Feed");
	}
	public void ActionDone(){
		animator.SetTrigger ("ActionDone");
	}
	public Transform Player{
		get{ return player; }
		set{ player = value; }
	}
	public Transform Target{
		get{ return target; }
		set{ target = value; }
	}
	public GameObject GrabbedObject{
		get{ return grabbedObject; }
		set{ grabbedObject = value; }
	}
}
