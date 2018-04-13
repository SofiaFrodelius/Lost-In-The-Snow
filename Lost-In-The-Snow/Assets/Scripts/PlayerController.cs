using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [Header("Character Settings")]
    [Range(0, 10f)]
    public float WalkingSpeed = 5f;
    [Range(1, 3f)]
    public float RunningSpeedModifier = 1.8f;
    [Range(0, 1f)]
    public float CrouchSpeedModifier = 0.5f;
    [Range(0, 10f)]
    public float JumpHeight = 2f;

    [Header("Temporary Stuff")]
    public GameObject WeaponHand;
    public Text rayText;
    public float maxInteractLength = 4f;
    public LayerMask interactLayerMask;

    private float speedModifier;
    private float JumpVelocity;
    private bool isCrouching = false;
    private bool isRunning = false;

    Vector3 movingVelocity;
    Vector3 movingVelocityController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        JumpVelocity = Mathf.Sqrt(2 * JumpHeight / -Physics.gravity.y) * -Physics.gravity.y;
    }

    void Update()
    {
        CalculateSpeed();
        Interact();

        movingVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), movingVelocity.y, Input.GetAxisRaw("Vertical"));
        movingVelocityController = new Vector3(Input.GetAxis("Left Stick Horizontal"), movingVelocityController.y, Input.GetAxis("Left Stick Vertical"));

        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            movingVelocity.y = JumpVelocity;
            movingVelocityController.y = JumpVelocity;
        }
        else
            movingVelocity.y += Physics.gravity.y * Time.deltaTime;
        movingVelocity.y = Mathf.Clamp(movingVelocity.y, Physics.gravity.y, 100f);
        movingVelocity = transform.TransformDirection(movingVelocity);

        //controller lazy fix
        movingVelocityController.y += Physics.gravity.y * Time.deltaTime;
        movingVelocityController.y = Mathf.Clamp(movingVelocityController.y, Physics.gravity.y, 100f);
        movingVelocityController = transform.TransformDirection(movingVelocityController);


        movingVelocity.x *= speedModifier;
        movingVelocity.z *= speedModifier;
        characterController.Move(movingVelocity * Time.deltaTime);
        //characterController.Move(speed * movingVelocityController * Time.deltaTime);

        //temporary stuff to deal with saves
        if (Input.GetKeyDown(KeyCode.X))
        {
            SaveLoad.saveLoad.Delete();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveLoad.saveLoad.playerPositionX = transform.position.x;
            SaveLoad.saveLoad.playerPositionY = transform.position.y;
            SaveLoad.saveLoad.playerPositionZ = transform.position.z;
            SaveLoad.saveLoad.sceneNumber = SceneManager.GetActiveScene().buildIndex;
            SaveLoad.saveLoad.Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveLoad.saveLoad.Load();
            transform.position = new Vector3
            (
                SaveLoad.saveLoad.playerPositionX,
                SaveLoad.saveLoad.playerPositionY,
                SaveLoad.saveLoad.playerPositionZ
            );



            //SceneHandler.ChangeScene(SaveLoad.saveLoad.sceneNumber);
        }
    }
    //Shit name 
    void CalculateSpeed()
    {
        speedModifier = WalkingSpeed;
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        isRunning = Input.GetKey(KeyCode.LeftShift);
        speedModifier *= (isCrouching ? CrouchSpeedModifier : 1f) * (isRunning ? RunningSpeedModifier : 1f);
        if (isCrouching)
            transform.GetChild(0).transform.localPosition = new Vector3(0, 0.5f, 0);
        else
            transform.GetChild(0).transform.localPosition = new Vector3(0, 1, 0);
    }


    //Function sends out a ray checking if object infront of player is interacteble
    void Interact()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxInteractLength, Color.red, 0.1f);
        if (Physics.Raycast(ray, out hit, maxInteractLength, interactLayerMask))
        {
            if (rayText != null)
                rayText.text = hit.transform.gameObject.name;
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExecuteEvents.ExecuteHierarchy<IInteractible>(hit.transform.gameObject, null, (handler, eventData) => handler.Interact());
                //ExecuteEvents.Execute<IGrabable> (hit.transform.gameObject, null, (handler, eventData) => handler.Grab (WeaponHand));
                ExecuteEvents.ExecuteHierarchy<IGrabable>(hit.transform.gameObject, null, pickup);
            }
        }
    }
    private void pickup(IGrabable handler, BaseEventData eventData)
    {
        Inventory inventory;
        inventory = Inventory.instance;
        Item item;
        handler.getItemOnPickup(out item);
        if(inventory != null)
            inventory.addItem(item);
    }
}
