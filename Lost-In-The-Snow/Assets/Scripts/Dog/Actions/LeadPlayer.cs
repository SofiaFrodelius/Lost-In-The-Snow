using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeadPlayer : DogAction{
    Transform player;
    Transform target;
	float maxDistance;
	DogAction currentAction;
	bool isWaiting;
	public LeadPlayer(Dog d, Transform player, Transform target, float maxDistance) : base(d){
        this.player = player;
		this.target = target;
		this.maxDistance = maxDistance;
    }
	public override void StartAction(){
		currentAction = new FollowTarget (dog, target, true);
		isWaiting = false;
	}
	//Måste även kolla om spelaren är närmare target etc..
    public override void UpdateAction(){
		currentAction.UpdateAction ();
		if (Vector3.Distance (player.position, dog.transform.position) < maxDistance || Vector3.Distance (player.position, target.position) < Vector3.Distance (dog.transform.position, target.position)) {
			if (isWaiting) {
				if (currentAction.IsDone ()) {
					currentAction = new FollowTarget (dog, target, true);
					isWaiting = false;
				}
			}
		} else {
			if (Vector3.Distance (player.position, target.position) > Vector3.Distance (dog.transform.position, target.position)) {
				if (!isWaiting) {
					currentAction.EndAction ();
					currentAction = new WaitForPlayer (dog, player,target, maxDistance);
					currentAction.StartAction ();
					isWaiting = true;
				}
			}
		}
    }
}
