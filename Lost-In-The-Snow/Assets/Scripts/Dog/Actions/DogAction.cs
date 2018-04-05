﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogAction : ScriptableObject{
	protected Dog dog;
	protected NavMeshAgent navAgent;
	protected Animator animator;
    protected bool isDone;
    public DogAction(Dog dog, NavMeshAgent navA, Animator anim){
        this.dog = dog;
        navAgent = navA;
        animator = anim;
        isDone = false;
    }
    public virtual void StartAction(){
    }
    public virtual void UpdateAction(){
    }
    public virtual void EndAction(){
    }
    public bool IsDone(){
        return isDone;
    }
}
