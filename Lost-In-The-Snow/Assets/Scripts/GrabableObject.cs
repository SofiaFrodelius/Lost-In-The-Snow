using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour, IGrabable {
	public GameObject Grab(GameObject parent){
		print ("GRABS ITEM");
		transform.parent = parent.transform;
		return gameObject;
	}
	public void Drop(){
		print ("DROPS ITEM");
		transform.parent = null;
	}
}
