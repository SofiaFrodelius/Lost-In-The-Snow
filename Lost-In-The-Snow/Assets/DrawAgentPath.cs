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
		navA.updatePosition = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 worldDeltaPosition = navA.nextPosition - navA.transform.position;

		// Map 'worldDeltaPosition' to local space
		float dx = Vector3.Dot (navA.transform.right, worldDeltaPosition);
		float dy = Vector3.Dot (navA.transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2 (dx, dy);

		float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
		smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

		// Update velocity if time advances
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;
		//print ("dx:" + dx + " dy:" + dy);
		print ("Velx: " + velocity.x + " Vely: " + velocity.y);

		lr.SetPositions (navA.path.corners);
	}
}
