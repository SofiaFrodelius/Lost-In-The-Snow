using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Drop : DogAction {
	Transform target;
	public Drop(Dog d, NavMeshAgent navA, Animator anim) : base(d,navA, anim){
        
	}
    public override void StartAction(){
//        dog.GrabbedItem;
        isDone = true;
        dog.print();
    }
    public override void UpdateAction(){
        //dog.print();
    }   
}
