using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DogAction))]
public class DogActionEditor : Editor {
	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
	}
}
