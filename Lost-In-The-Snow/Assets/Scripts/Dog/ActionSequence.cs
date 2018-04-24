using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionSequence : MonoBehaviour {
	public UnityEvent MyEvent;
	// Use this for initialization
	void Start () {
		MyEvent.Invoke ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
