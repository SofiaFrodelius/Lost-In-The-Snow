﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : DogAction {
	public override void OnActionStart(){
		//Get happy
		animator.SetTrigger ("ActionDone");
    }
	public override void OnActionUpdate(){
	}
	public override void OnActionEnd(){
	}
}
