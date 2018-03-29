using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicNavMesh : MonoBehaviour {
    NavMeshSurface navSurface;
	// Use this for initialization
	void Start () {
        navSurface = GetComponent<NavMeshSurface>();
        //StartCoroutine("BuildNav");
        navSurface.BuildNavMesh();
    }
	
	// Update is called once per frame
	void Update () {
    }
}
