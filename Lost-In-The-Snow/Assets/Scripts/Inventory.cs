using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static Inventory instance; //singleton


    public int numOfSlots = 10;
    private InventorySlot[] inventorySlots;
    private int numOfUsedSlots = 0;
    public Item testItem; //temp


    public delegate void InventoryChanged();
    public InventoryChanged inventoryChangedCallback;
    InventoryHUD inventoryHUD;


    private void Awake()
    {
        inventoryHUD = InventoryHUD.instance;

        if(instance != null)
        {
            Debug.LogWarning("More than one instance of class inventory in scene.");
            return;
        }
        instance = this;
    }


    public void Start()
    {
        inventorySlots = new InventorySlot[numOfSlots];

        for(int i = 0; i < numOfSlots; i++)
        {
            inventorySlots[i] = new InventorySlot();
        }
    }


    //tempkod
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) inventoryHUD.showInventory();
    }





    public Item getItemFromSlot(int slot)
    {
        return inventorySlots[slot].getItem();
    }

    public int getNumOfItemsInSlot(int slot)
    {
        return inventorySlots[slot].getItemsInSlot();
    }

    public void addItem(Item item)
    {


        for(int i = 0; i < numOfUsedSlots; i++)
        {
            if(inventorySlots[i].getItem() != null && inventorySlots[i].getItem().getId() == item.getId())
            {
                if(inventorySlots[i].getItemsInSlot() < item.getMaxStack())
                {
                    inventorySlots[i].incrementItemsInSlot();
                    inventoryChangedCallback.Invoke();
                    return;
                }
            }
        }

        if(numOfUsedSlots == numOfSlots)
        {
            Debug.Log("Inventory is full. Could not add item to inventory.");
            return;
        }

        else
        {
            inventorySlots[numOfUsedSlots].setItem(item);
            inventorySlots[numOfUsedSlots].incrementItemsInSlot();
            inventoryChangedCallback.Invoke();
            numOfUsedSlots++;
        }


    }





}
