using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Drop : DogAction {
	Transform target;
	public Drop(Dog d) : base(d){
        
	}
    public override void StartAction(){
        dog.DropGrabbedItem();
        isDone = true;
    }
}
