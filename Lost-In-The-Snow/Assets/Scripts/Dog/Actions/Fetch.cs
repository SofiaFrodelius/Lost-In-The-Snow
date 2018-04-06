using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Fetch : DogAction{
    Transform item;
    Transform player;
    DogAction currentAction;
    List<DogAction> actions = new List<DogAction>();
    int actionCount;
    public Fetch(Dog d, NavMeshAgent navA, Animator anim, Transform item, Transform player) : base(d, navA, anim){
        this.item = item;
        this.player = player;
        actionCount = 0;
        actions.Add(new FollowTarget(d, navA, anim, item, true));
        actions.Add(new Grab(d, navA, anim, item.gameObject));
        actions.Add(new FollowTarget(d, navA, anim, player, true));
        actions.Add(new Drop(d, navA, anim));
        actions.Add(new FollowPlayer(d, navA, anim,player));
        NextAction();
    }
    public override void UpdateAction(){
        if (!isDone){
            if (currentAction.IsDone())
                NextAction();
            currentAction.UpdateAction();
        }
    }
    void NextAction(){
        if (actionCount < actions.Count){
            currentAction = actions[actionCount];
            currentAction.StartAction();
            actionCount++;
        }else
            isDone = true;
    }
}
