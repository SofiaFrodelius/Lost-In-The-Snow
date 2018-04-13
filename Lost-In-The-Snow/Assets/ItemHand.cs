using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHand : MonoBehaviour
{
    private int selectedItem = 0;
    private int numOfItemsInHand = 0;
    private int scroll = 0;
    private GameObject activeItem = null;
    Inventory inventory;

    public void Start()
    {
        inventory = Inventory.instance;
        inventory.holdaBleItemsChangedCallback += updateItemInHand;
    }

    public void Update()
    {
        if (Input.GetAxis("Scroll") > 0.1) scroll = 1;
        else if (Input.GetAxis("Scroll") < -0.1) scroll = -1;
        else scroll = 0;

        if (scroll != 0 && inventory.getNumOfUsedHoldableSlots() > 1)
        {
            selectedItem += scroll;
            if (selectedItem >= inventory.getNumOfUsedHoldableSlots()) selectedItem = 0;
            else if (selectedItem < 0) selectedItem = inventory.getNumOfUsedHoldableSlots() - 1;
            updateItemInHand();
            Debug.Log(selectedItem);
        }
    }

    public void updateItemInHand()
    {
        if (activeItem != null) Destroy(activeItem);
        Debug.Log("Item destroyed.");

        activeItem = Instantiate(inventory.getObjectFromHoldableSlot(selectedItem),transform);
    }

}
