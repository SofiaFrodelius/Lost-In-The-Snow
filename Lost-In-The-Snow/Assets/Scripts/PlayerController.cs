using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    Vector3 movingVelocityController;
    private void Awake(){
        characterController = GetComponent<CharacterController>();
        TimeToApex = JumpHeight / Physics.gravity.y;
        jumpVelocity = Physics.gravity.y * TimeToApex;
    }
    void Update(){
        if (Input.GetKey(KeyCode.E)) {
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            if (Physics.Raycast(ray, out hit)){
                ExecuteEvents.Execute<IInteractible>(hit.transform.gameObject, null, (handler, eventData) => handler.Interact());

            }
        }

        movingVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), movingVelocity.y, Input.GetAxisRaw("Vertical"));
        movingVelocityController = new Vector3(Input.GetAxis("Left Stick Horizontal"), movingVelocityController.y, Input.GetAxis("Left Stick Vertical"));

        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            movingVelocity.y = jumpVelocity;
            movingVelocityController.y = jumpVelocity;
        }
        else
            movingVelocity.y += Physics.gravity.y * Time.deltaTime;
        movingVelocity.y = Mathf.Clamp(movingVelocity.y, Physics.gravity.y, 100f);
        movingVelocity = transform.TransformDirection(movingVelocity);

        //controller lazy fix
        movingVelocityController.y += Physics.gravity.y * Time.deltaTime;
        movingVelocityController.y = Mathf.Clamp(movingVelocityController.y, Physics.gravity.y, 100f);
        movingVelocityController = transform.TransformDirection(movingVelocityController);


        characterController.Move(speed * movingVelocity * Time.deltaTime);
        characterController.Move(speed * movingVelocityController * Time.deltaTime);
    }
}
