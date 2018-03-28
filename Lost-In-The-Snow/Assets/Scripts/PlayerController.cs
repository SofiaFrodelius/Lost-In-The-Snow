using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    CharacterController characterController;
    [Header("Character Settings")]
    [Range(0, 10f)]
    public float speed = 10f;
    [Range(0, 10f)]
    public float JumpHeight = 2f;
    private float jumpVelocity;
    private float TimeToApex;
    Vector3 movingVelocity;
    private void Awake(){
        characterController = GetComponent<CharacterController>();
        TimeToApex = JumpHeight / Physics.gravity.y;
        jumpVelocity = Physics.gravity.y * TimeToApex;
    }
    void Update(){
        movingVelocity = new Vector3(Input.GetAxis("Horizontal"), movingVelocity.y, Input.GetAxis("Vertical"));
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            movingVelocity.y = jumpVelocity;
        else
            movingVelocity.y += Physics.gravity.y*Time.deltaTime;
        movingVelocity.y = Mathf.Clamp(movingVelocity.y, Physics.gravity.y, 100f);
        movingVelocity = transform.TransformDirection(movingVelocity);
        characterController.Move(speed * movingVelocity * Time.deltaTime);
    }
}
