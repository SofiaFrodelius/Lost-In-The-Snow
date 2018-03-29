using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogMovement : MonoBehaviour, IInteractible {
    public Transform player;

    NavMeshAgent navAgent;
	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
	}
    public void Interact(){
        DogAction dogAction = new Pet(gameObject, player);
        dogAction.StartAction();
    }
}
