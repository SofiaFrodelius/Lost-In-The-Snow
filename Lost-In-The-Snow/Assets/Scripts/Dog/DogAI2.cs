using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAI2 : MonoBehaviour {
	private Dog dog;
	void Start(){
		dog = GetComponent<Dog> ();

		
	}
	void Update(){
		if (dog.currentAction != null) {
			if (dog.currentAction.IsDone ()) {
				EndCurrentAction ();
			} else if (!dog.player.GetComponent<CharacterMovement> ().getSprint ()) {
				if (dog.currentAction.GetImportance () != DogAction.Importance.HIGH) {
					EndCurrentAction ();
					dog.currentAction = new FollowPlayer(dog, dog.player);
					dog.currentAction.StartAction ();
				}
			}
		}
	}
	void EndCurrentAction(){
		dog.currentAction.EndAction ();
		dog.currentAction = null;
	}
}
