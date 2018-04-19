using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trigger : MonoBehaviour {
    //public coll trigger.collider();

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
