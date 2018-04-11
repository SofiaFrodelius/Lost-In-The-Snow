using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WaitForPlayer : DogAction{
    Transform player;
	Transform target;
    float distance;
	public WaitForPlayer(Dog d, Transform player,Transform target, float distance): base(d){
        this.player = player;
		this.target = target;
        this.distance = distance;
    }
	public override void StartAction(){
	}
    public override void UpdateAction(){
		if(Vector3.Distance(dog.transform.position, player.position) < distance || Vector3.Distance (player.position, target.position) < Vector3.Distance (dog.transform.position, target.position)){
				//Wait for animation
				isDone = true;
        }
        else{
			//Look at player
        }
    }
}
