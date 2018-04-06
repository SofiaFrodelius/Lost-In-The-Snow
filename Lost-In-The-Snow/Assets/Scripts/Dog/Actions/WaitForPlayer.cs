using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WaitForPlayer : DogAction{
    Transform player;
    float distance;
    public WaitForPlayer(Dog d, NavMeshAgent navA, Animator anim, Transform player, float distance): base(d,navA, anim){
        this.player = player;
        this.distance = distance;
    }
    public override void UpdateAction(){
        if(Vector3.Distance(dog.transform.position, player.position) < distance){
            isDone = true;
        }
        else{
            //woof
        }
    }
}
