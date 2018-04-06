using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : DogAction{
    Transform target;
    bool isAtTarget;
    bool doneAtTarget;
    float width = 1.5f;
    public FollowTarget(Dog d, Transform target, bool doneAtTarget) : base(d){
        this.target = target;
        this.doneAtTarget = doneAtTarget;
    }
    public override void UpdateAction(){
        if (!isDone){
            if (Vector3.Distance(dog.transform.position, target.position) > width){
                isAtTarget = false;
                navAgent.SetDestination(target.position);
            }
            else{
                if (doneAtTarget)
                    isDone = true;
                isAtTarget = true;
            }
        }
    }
    public override void EndAction(){
        navAgent.ResetPath();
    }
    public bool IsAtTarget(){
        return isAtTarget;
    }
}
