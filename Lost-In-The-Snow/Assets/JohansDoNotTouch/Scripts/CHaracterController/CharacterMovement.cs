using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    [SerializeField] private AnimationCurve moveAccelaration;
    [Range(0, 10f)]
    [SerializeField] private float movementSpeed;
    [Range(1, 3f)][Tooltip("1 is equal to movementSpeed")]
    [SerializeField] private float sprintMultiplier;
    [Range(0, 10f)]
    [SerializeField] private float jumpStartSpeed;
    [Range(0, 3)]
    [SerializeField] private float fallMultiplier;

    private float inputH, inputV;
    private bool inputSprint, inputJump, allowedToJump;
    private CharacterController cc;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        

    }
	
	// Update is called once per frame
	void Update (){
        CheckInputs();
        CalculateMovement();
        CalculateCurrentSpeed();
        CalculateJump();
        CalculateAirTime();
        ApplyMovement();

    }
    void CalculateAirTime()
    {
        float dt = Time.deltaTime;

        if (cc.velocity.y < 0)
        {
            moveDirection.y += dt * fallMultiplier * Physics.gravity.y;
        }
        else
        {
            moveDirection.y += dt * Physics.gravity.y;
        }
    }
    
    void CalculateJump()
    {
        if (inputJump && cc.isGrounded)
        {
            moveDirection.y = jumpStartSpeed;
        }
    }
    
    void CalculateMovement()
    {
        Vector3 lookDir = Camera.main.transform.forward;
        moveDirection = new Vector3(inputH, lastMoveDirection.y, inputV);   

    }
    void ApplyMovement()
    {
        moveDirection = transform.TransformDirection(moveDirection);
        cc.Move(moveDirection * Time.deltaTime);
        lastMoveDirection = moveDirection;
    }


    private void CalculateCurrentSpeed()
    {
        //float dt = Time.deltaTime;
        moveDirection.x *= movementSpeed;
        moveDirection.z *= movementSpeed;
        moveDirection.x *= inputSprint ? sprintMultiplier : 1.0f;
        moveDirection.z *= inputSprint ? sprintMultiplier : 1.0f;
    }
    private void CheckInputs()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        inputSprint = Input.GetButton("Sprint") ? true : false;
        inputJump = Input.GetButtonDown("Jump") ? true : false;

    }
    public bool getSprint()
    {
        return inputSprint;
    }

}
