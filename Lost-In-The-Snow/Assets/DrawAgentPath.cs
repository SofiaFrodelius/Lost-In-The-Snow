using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawAgentPath : MonoBehaviour {

	LineRenderer lr;
	public NavMeshAgent navA;
	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;
	void Start () {
		lr = GetComponent<LineRenderer> ();
		//navA.updatePosition = false;
	}
}
