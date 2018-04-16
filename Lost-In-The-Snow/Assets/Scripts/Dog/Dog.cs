using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour, IInteractible {
	public LayerMask dogLayerMask;
	public Transform player;
	public Transform itemBone;
	[Header("Debug Tools")]
	public Transform TestWaypoint;
    public Item grabbedItem;
    public GameObject itemObject;

    private NavMeshAgent navAgent;
	private Animator animator;

    public DogAction currentAction;

	public Mood currentMood;
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
		currentMood.ChangeMood (50f, 0f, 30f, 0f);
    }
	void Update(){
        if (currentAction != null)
            currentAction.UpdateAction();
    }
	public void Print(int test){
		print (test);
	}
	public void Interact(){}
	public void AddEffectToMood(Mood effect){
		currentMood = currentMood + effect;
	}
    public Item GrabbedItem{
        get{ return grabbedItem; }
        set{
            if (value != null) { 
				DropGrabbedItem();
                grabbedItem = value;
				itemObject = Instantiate(grabbedItem.getAssociatedGameobject(), itemBone) as GameObject;
				itemObject.transform.parent = itemBone;
                itemObject.GetComponent<Rigidbody>().isKinematic = true;
                itemObject.transform.localPosition = Vector3.zero;
                itemObject.transform.localRotation = Quaternion.identity;
			}
        }
    }
    public void DropGrabbedItem(){
        if(itemObject != null){
			itemObject.transform.parent = null;
            itemObject.GetComponent<Rigidbody>().isKinematic = false;
			grabbedItem = null;
			itemObject = null;
        }
    }
	public void gprint(string test){
		print (test);
	}
}
