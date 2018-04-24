using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChracterInteract : MonoBehaviour
{
    [SerializeField] private float maxInteractLength;
    [SerializeField] private LayerMask interactLayerMask;
    private Camera playerCam;
    // Use this for initialization
    void Start()
    {
        playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        CallDog();

    }


    void CallDog()
    {
        print("hej");
        if (Input.GetButtonDown("CallDog"))
        {
            print("hejdå");
            print("ROPAR ILAAAAA!");
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
                Debug.Log(hit.transform.gameObject.name);
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
        handler.getItemOnPickup(out item);
        if (inventory != null)
            inventory.addItem(item);
    }
}