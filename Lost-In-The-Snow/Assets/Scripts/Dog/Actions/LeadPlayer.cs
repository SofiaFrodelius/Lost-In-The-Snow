using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeadPlayer : DogAction{
    Transform player;
    Transform target;
    public LeadPlayer(Dog d, Transform player, Transform target) : base(d){
        this.player = player;
    }
    public override void UpdateAction(){
    }
}
