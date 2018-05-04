﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static Inventory instance; //singleton


    public int numOfSlots = 5;
    public int numOfHoldableSlots = 1;
    private List<InventorySlot> inventorySlots;
    private List<InventorySlot> holdableSlots;
    private int numOfUsedSlots = 0;
    private int numOfUsedHoldableSlots;
    public Item testItem; //temp


    public delegate void InventoryChanged();
    public InventoryChanged inventoryChangedCallback;
    public delegate void HoldableItemsChanged(int sItem);
    public HoldableItemsChanged holdableItemsChangedCallback;
    public delegate void UpdateItemInHand();
    public UpdateItemInHand updateItemInHandCallback;


    InventoryHUD inventoryHUD;


    private void Awake()
    {
        inventoryHUD = InventoryHUD.instance;

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of class inventory in scene.");
            return;
        }
        instance = this;
    }


    public void Start()
    {
        inventorySlots = new List<InventorySlot>();
        holdableSlots = new List<InventorySlot>();
    }


    //temporärkod
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) removeHoldableItem(0);
    }

    public Item getItemFromSlot(int slot)
    {
        if (inventorySlots.Count > slot)
            return inventorySlots[slot].getItem();
        else return null;
    }

    public Item getItemFromHoldableSlot(int slot)
    {
        if (holdableSlots.Count > slot)
            return holdableSlots[slot].getItem();
        else return null;
    }

    public int getNumOfItemsInSlot(int slot)
    {
        if (inventorySlots.Count > slot)
            return inventorySlots[slot].getItemsInSlot();
        else return 0;
    }

    public void addItem(Item item)
    {
        if (!item.getHoldable())
        {
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i].getItem() != null && inventorySlots[i].getItem().getId() == item.getId())
                {
                    if (inventorySlots[i].getItemsInSlot() < item.getMaxStack())
                    {
                        inventorySlots[i].incrementItemsInSlot();
                        inventoryChangedCallback.Invoke();
                    }
                    return;
                }
            }

            if (inventorySlots.Count == numOfSlots)
            {
                Debug.Log("Inventory is full. Could not add item to inventory.");
                return;
            }

            if (inventorySlots.Count < numOfSlots)
            {
                inventorySlots.Add(new InventorySlot());
                inventorySlots[inventorySlots.Count - 1].setItem(item);
                inventorySlots[inventorySlots.Count - 1].incrementItemsInSlot();
                inventoryChangedCallback.Invoke();
            }
        }

        else
        {
            for (int i = 0; i < holdableSlots.Count; i++)
            {
                if (holdableSlots[i].getItem() != null && holdableSlots[i].getItem().getId() == item.getId())
                {
                    if (holdableSlots[i].getItemsInSlot() < item.getMaxStack())
                    {
                        holdableSlots[i].incrementItemsInSlot();
                        inventoryChangedCallback.Invoke();
                        return;
                    }
                }
            }

            if (holdableSlots.Count == numOfSlots)
            {
                Debug.Log("Inventory is full. Could not add item to inventory.");
                return;
            }

            if (holdableSlots.Count < numOfHoldableSlots)
            {
                holdableSlots.Add(new InventorySlot());
                holdableSlots[holdableSlots.Count - 1].setItem(item);
                holdableSlots[holdableSlots.Count - 1].incrementItemsInSlot();
                if (updateItemInHandCallback != null)
                    updateItemInHandCallback.Invoke();
            }
        }
    }

    public void removeHoldableItem(int slotId)
    {
        if (getNumOfUsedHoldableSlots() > 0)
        {
            if (holdableSlots[slotId].getItemsInSlot() > 1)
            {
                holdableSlots[slotId].decrementItemsInSlot();
            }
            else
            {
                holdableSlots.Remove(holdableSlots[slotId]);
                updateItemInHandCallback.Invoke();
            }
        }
    }

    public void removeNonHoldableItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].getItem() == item)
            {
                if (inventorySlots[i].getItemsInSlot() > 1)
                {
                    inventorySlots[i].decrementItemsInSlot();
                }
                else
                {
                    inventorySlots.Remove(inventorySlots[i]);
                }
                inventoryChangedCallback.Invoke();
                return;
            }
        }
    }


    public int getNumOfHoldableSlots()
    {
        return numOfHoldableSlots;
    }
    public int getNumOfUsedHoldableSlots()
    {
        return holdableSlots.Count;
    }

    public GameObject getObjectFromHoldableSlot(int i)
    {
        if (holdableSlots[i].getItem() != null)
            return holdableSlots[i].getItem().getAssociatedGameobject();
        else return null;
    }

}
