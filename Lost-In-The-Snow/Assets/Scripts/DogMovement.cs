using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogMovement : MonoBehaviour, IDogHandler {
    public Transform player;
    NavMeshAgent navAgent;
	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frameX 
	void Update () {
        navAgent.SetDestination(player.position + player.forward);
	}
    public void Pet(){
        transform.Translate(new Vector3(0, 10, 0));
    }
    public void Interact()
    {

    }
}
