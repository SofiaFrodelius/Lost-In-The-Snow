using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChracterInteract : MonoBehaviour
{
    [SerializeField] private float maxInteractLength;
    [SerializeField] private LayerMask interactLayerMask;
    private Camera playerCam;
	private Dog dog;
    // Use this for initialization
    void Start()
    {
        playerCam = Camera.main;
		dog = GameObject.FindWithTag ("Dog").GetComponent<Dog>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        CallDog();
        InteractWithDog();
        PickUpDog();
    }


    void CallDog()
    {
        if (Input.GetButtonDown("CallDog"))
        {
			dog.Call (transform);
        }
    }
    void PickUpDog()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Input.GetButtonDown("PickupDog"))
        {
            if (Physics.Raycast(ray, out hit, maxInteractLength, interactLayerMask))
            {
                Debug.Log(hit.transform.gameObject.name);
				dog.PickupDog ();
                //HUNDJÄVELN SKA UPP I FAMNHELVETET
            }
        }
    }
    void InteractWithDog()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Input.GetButtonDown("PetDog"))
        {
            if (Physics.Raycast(ray, out hit, maxInteractLength, interactLayerMask))
            {
                Debug.Log(hit.transform.gameObject.name);
				dog.Pet ();
            }
        }
    }
    void Interact()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Input.GetButtonDown("Interact"))
        {
            
            if (Physics.Raycast(ray, out hit, maxInteractLength, interactLayerMask))
            {
                ExecuteEvents.ExecuteHierarchy<IInteractible>(hit.transform.gameObject, null, (handler, eventData) => handler.Interact());
                ExecuteEvents.ExecuteHierarchy<IGrabable>(hit.transform.gameObject, null, pickup);
            }
        }
    }

    //callback funktion for iGrabable
    private void pickup(IGrabable handler, BaseEventData eventData)
    {
        Inventory inventory;
        inventory = Inventory.instance;
        Item item;
        item = handler.getItemOnPickup();
        handler.destroyItem();
        if (inventory != null)
            inventory.addItem(item);
    }
}