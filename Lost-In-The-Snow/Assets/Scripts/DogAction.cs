using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAction : ScriptableObject {
    protected GameObject dog;
    protected bool isActive;
    public DogAction (GameObject gameObject){
        dog = gameObject;
    }
    public virtual void StartAction() {
    }
    public virtual void EndAction() { }
}
