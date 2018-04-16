using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DogAI))]
public class DogAIEditor : Editor {
	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		DogAI dogAi = (DogAI)target;
		MonoScript script = null;
		script = EditorGUILayout.ObjectField(script, typeof(MonoScript), false) as MonoScript;
	}
}
