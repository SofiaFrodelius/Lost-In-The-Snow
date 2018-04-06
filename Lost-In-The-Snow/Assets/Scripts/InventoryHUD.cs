using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    public static InventoryHUD instance;
    Inventory inventory;
    private InventorySlotHUD[] inventorySlots;


    public InventoryHUD()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of class InventoryHUD in scene.");
            return;
        }
        instance = this;
    }



    public void Start()
    {
        inventorySlots = GetComponentsInChildren<InventorySlotHUD>();
        inventory = Inventory.instance;
        inventory.inventoryChangedCallback += updateHUD;
    }





    public void updateHUD()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            Item current = inventory.getItemFromSlot(i);
            if(current != null)
            {
                inventorySlots[i].updateSlot(current, inventory.getNumOfItemsInSlot(i));
            }
        }
    }
}
