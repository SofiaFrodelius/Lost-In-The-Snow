using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    private Animator anim;
    private CharacterController cc;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        cc = transform.parent.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(cc.velocity.x != 0 && cc.isGrounded || cc.velocity.z != 0 && cc.isGrounded)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if(transform.parent.GetComponent<CharacterMovement>().getSprint() && cc.isGrounded)
        {
            anim.SetBool("IsSprinting", true);
        }
        else
        {
            anim.SetBool("IsSprinting", false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsChopping", true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            anim.SetBool("IsChopping", false);
        }
	}
}
