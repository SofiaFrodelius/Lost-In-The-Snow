using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    CharacterController characterController;
    public float speed = 10f;
    private void Awake(){
        characterController = GetComponent<CharacterController>();
    }
    void Update(){
        Vector3 movingVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            movingVelocity.y = 209f;
        else
            movingVelocity.y -= 9.82f*Time.deltaTime;
        characterController.Move(speed * movingVelocity * Time.deltaTime);
    }
}
