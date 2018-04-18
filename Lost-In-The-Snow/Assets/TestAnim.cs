using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour {
    private Animator anim;
    bool InspectBool = false;
    bool TreeChopBool = false;
    [SerializeField] private ParticleSystem[] particles;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) InspectBool = true;
        if (Input.GetKeyUp(KeyCode.F)) InspectBool = false;
        if (Input.GetMouseButtonDown(0)) TreeChopBool = true;
        if (Input.GetMouseButtonUp(0)) TreeChopBool = false;
        anim.SetBool("InspectBool", InspectBool);
        anim.SetBool("TreeChopBool", TreeChopBool);

        
        
    }
    public void AxeHit()
    {
        foreach(ParticleSystem p in particles)
        {
            p.Play();
        }
    }
}
