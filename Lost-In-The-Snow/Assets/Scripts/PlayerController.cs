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
                ExecuteEvents.Execute<IDogHandler>(hit.transform.gameObject, null, (handler, eventData) => handler.Pet());
            }
        }

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
