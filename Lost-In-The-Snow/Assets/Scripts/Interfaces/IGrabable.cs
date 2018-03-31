using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IGrabable : IEventSystemHandler{
	GameObject Grab(GameObject parent);
	void Drop();
}
