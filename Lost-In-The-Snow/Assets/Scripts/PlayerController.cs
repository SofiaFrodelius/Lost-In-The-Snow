using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    CharacterController characterController;
    public float speed = 10f;
    public float TimeToApex = 1f;
    public float JumpHeight = 2f;
    private float jumpVelocity;
    Vector3 movingVelocity;
    private void Awake(){
        characterController = GetComponent<CharacterController>();
        jumpVelocity = Mathf.Abs(2*JumpHeight/Mathf.Pow(TimeToApex,2)) * TimeToApex / 2;
    }
    void Update(){
        movingVelocity = new Vector3(Input.GetAxis("Horizontal"), movingVelocity.y, Input.GetAxis("Vertical"));
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            movingVelocity.y = jumpVelocity;
        else
            movingVelocity.y += Physics.gravity.y*Time.deltaTime;
        movingVelocity.y = Mathf.Clamp(movingVelocity.y, Physics.gravity.y, 100f);
        characterController.Move(speed * movingVelocity * Time.deltaTime);
    }
}
