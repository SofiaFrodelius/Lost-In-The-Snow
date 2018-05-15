    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour, IInteractible
{
    
    private ParticleSystem particleSys; 
	// Use this for initialization
	void Start () {
        particleSys = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        //light fire
        //activate crackling sound
        //start Particle System
        Debug.Log("Brasa");

        ToggleFire();
    }
    void ToggleFire()
    {
        if (particleSys.isPlaying) particleSys.Stop();
        else particleSys.Play();
    }

    public void AlternateInteract()
    {
        throw new System.NotImplementedException();
    }
}
