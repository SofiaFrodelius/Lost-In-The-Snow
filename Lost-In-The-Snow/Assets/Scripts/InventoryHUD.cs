﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    public static InventoryHUD instance;
    Inventory inventory;
    private InventorySlotHUD[] inventorySlots;
    private HoldableInventorySlotHUD[] holdableInventorySlots;


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
        holdableInventorySlots = GetComponentsInChildren<HoldableInventorySlotHUD>();
        inventory = Inventory.instance;
        if (inventory != null)
        {
            inventory.inventoryChangedCallback += updateInventoryHUD;
            inventory.holdableItemsChangedCallback += updateHoldableItemsHUD;
        }
    }



    public void updateInventoryHUD()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            Item current = inventory.getItemFromSlot(i);
            if (current != null)
            {
                inventorySlots[i].updateSlot(current, inventory.getNumOfItemsInSlot(i));
            }
        }
    }

    public void updateHoldableItemsHUD(int sItem)
    {
        sItem -= 1;
        if (sItem < 0) sItem = inventory.getNumOfUsedHoldableSlots()-1;
        for(int i = 0; i < holdableInventorySlots.Length; i++)
        {

            Item current = inventory.getItemFromHoldableSlot(sItem);
            if(current  != null)
            {
                holdableInventorySlots[i].updateSlot(current);
            }


            sItem++;
            if (sItem >= inventory.getNumOfUsedHoldableSlots()) sItem = 0;
        }
    }


    public void showInventory()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].getCurrentItem() != null)
                inventorySlots[i].showInventorySlot();
        }
    }
}
