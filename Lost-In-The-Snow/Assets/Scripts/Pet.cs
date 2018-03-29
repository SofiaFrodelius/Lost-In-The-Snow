using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : DogAction {
    Transform target;
    public Pet(GameObject gameObject, Transform target): base(gameObject) {
        this.target = target;
    }
    public override void StartAction(){
        isActive = true;
        //Kalla på UpdateDestnation Och borde följa target tills EndAction körs
    }
    public override void EndAction(){
        isActive = false;
    }
    IEnumerable UpdateDestination(float time){
        while (isActive){
            dog.GetComponent<NavMeshAgent>().SetDestination(target.position);
            yield return new WaitForSeconds(time);
        }
    }
}
