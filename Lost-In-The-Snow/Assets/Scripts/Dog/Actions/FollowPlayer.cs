using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class FollowPlayer : DogAction{
    Transform player;
    FollowTarget followTarget;
    public FollowPlayer(Dog d, NavMeshAgent navA, Animator anim, Transform player) : base(d, navA, anim){
        this.player = player;
        followTarget = new FollowTarget(d, navA, anim, player, false);
    }
    public override void UpdateAction(){
        followTarget.UpdateAction();
    }
}
