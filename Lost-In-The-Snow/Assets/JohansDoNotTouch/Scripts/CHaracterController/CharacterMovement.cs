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
    [SerializeField] private bool canJump;

    private float inputH, inputV;
    private bool inputSprint, inputJump, allowedToJump;
    private CharacterController cc;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;

    private bool moving = false;
    private bool toggledMoving = false;
    private Timer accTajmer;

    CharacterController characterController;
    CameraController cameraController;

    //Needed to load saved position when switching scenes, WILL BE REMOVED LATER
    private void Awake()
    {
        cameraController = GetComponentInChildren<CameraController>();
        characterController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        accTajmer = new Timer(0f);
        if (SaveLoad.saveLoad.newGame == false) // WILL ALSO BE REMOVED LATER
        {
            cameraController.setLook(new Vector2(SaveLoad.saveLoad.lookX, SaveLoad.saveLoad.lookY));
            transform.position = new Vector3
             (
            SaveLoad.saveLoad.playerPositionX,
            SaveLoad.saveLoad.playerPositionY,
            SaveLoad.saveLoad.playerPositionZ
            );
        }
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
        else if (cc.velocity.y > 0 && !Input.GetButton("Jump"))
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
        moveDirection.x *= movementSpeed * getAcceleration();
        moveDirection.z *= movementSpeed * getAcceleration();
        moveDirection.x *= inputSprint ? sprintMultiplier : 1.0f;
        moveDirection.z *= inputSprint ? sprintMultiplier : 1.0f;
    }
    private void CheckInputs()
    {
        moving = Input.GetButton("Horizontal") == true || Input.GetButton("Vertical") == true ? true : false;
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");       
        inputSprint = Input.GetButton("Sprint") ? true : false;
        if(canJump) inputJump = Input.GetButtonDown("Jump") ? true : false;
        
    }
    public bool getSprint()
    {
        return inputSprint;
    }
    private float getAcceleration()
    {
        float tmp = 0;
        AddTakeTame();
        tmp =  moveAccelaration.Evaluate(accTajmer.Time);
        return tmp > 1 ? 1 : tmp;
    }

    void AddTakeTame()
    {
        if (moving) accTajmer.AddTime(Time.deltaTime);
        else accTajmer.ResetTimer();
    }

}
