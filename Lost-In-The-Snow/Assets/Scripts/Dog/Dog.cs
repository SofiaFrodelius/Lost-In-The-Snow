using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour, IInteractible {
	public Transform player;
	public Transform target;
    public Transform bone;
    public GameObject TESTBONE;
	public Transform TestWaypoint;

    public Item grabbedItem;
    public GameObject itemObject;

    private NavMeshAgent navAgent;
	private Animator animator;

    public DogAction currentAction;
    public List<DogAction> dogActions = new List<DogAction>();
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //navAgent.updatePosition = false;
		//navAgent.updateRotation = false;
        dogActions.Add(new FollowPlayer(this, player));
        //currentAction = dogActions[0];
        //currentAction = new Fetch(this, TESTBONE.transform, player);
		currentAction = new LeadPlayer(this, player, TestWaypoint, 10f); 
		currentAction.StartAction ();
    }
	void Update(){
        if (currentAction != null)
            currentAction.UpdateAction();
    }
	public void Interact(){}
    public Item GrabbedItem{
        get{ return grabbedItem; }
        set{
            if (value != null) { 
                grabbedItem = value;
                DropGrabbedItem();
                itemObject = Instantiate(grabbedItem.getAssociatedGameobject(), bone) as GameObject;
                itemObject.GetComponent<Rigidbody>().isKinematic = true;
                itemObject.transform.localPosition = Vector3.zero;
                itemObject.transform.localRotation = Quaternion.identity;
            }
        }
    }
    public void DropGrabbedItem(){
        if(itemObject != null){
            itemObject.GetComponent<Rigidbody>().isKinematic = false;
            itemObject.transform.parent = null;
        }
    }
}
