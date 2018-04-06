using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class FollowPlayer : DogAction{
    Transform player;
    FollowTarget followTarget;
    public FollowPlayer(Dog d, Transform player) : base(d){
        this.player = player;
        followTarget = new FollowTarget(d, player, false);
    }
    public override void UpdateAction(){
        followTarget.UpdateAction();
    }
}
