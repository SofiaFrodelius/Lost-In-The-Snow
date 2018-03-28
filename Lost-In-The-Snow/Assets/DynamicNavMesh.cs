using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicNavMesh : MonoBehaviour {
    NavMeshSurface navSurface;
	// Use this for initialization
	void Start () {
        navSurface = GetComponent<NavMeshSurface>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate(){
        //navSurface.BuildNavMesh();
    }
}
