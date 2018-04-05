using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour, IInteractible {
	public Transform player;
	public Transform target;
    public Transform bone;
    public GameObject TESTBONE;

    public Item grabbedItem;
    public GameObject itemObject;

    private NavMeshAgent navAgent;
	private Animator animator;

    private DogAction currentAction;
    public List<DogAction> dogActions = new List<DogAction>();
	void Awake(){
        navAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator> ();
	}
	void Start () {
		animator.SetTrigger ("Fetch");
        dogActions.Add(new FollowPlayer(this,navAgent, animator, player));
        //currentAction = dogActions[0];
        currentAction = new Fetch(this, navAgent, animator, TESTBONE.transform, player);
    }
    void FixedUpdate() {
        if(currentAction != null)
            currentAction.UpdateAction();
    }
	void Update(){
		if (Input.GetKey (KeyCode.Q)) {
        }
	}
	public void Interact(){
        DogAction waitForPlayer = new WaitForPlayer(this,navAgent, animator, player, 3f);
	}
    public Item GrabbedItem{
        get{ return grabbedItem; }
        set{
            if (value != null) { 
                grabbedItem = value;
                if (itemObject != null){
                    itemObject.GetComponent<Rigidbody>().isKinematic = false;
                    itemObject.transform.parent = null;
                }
                itemObject = Instantiate(grabbedItem.getAssociatedGameobject(), bone) as GameObject;
                itemObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
    public void print()
    {
        print("HEJSAN");
    }
}
