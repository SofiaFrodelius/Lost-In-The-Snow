using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VoiceLinePromt))]
public class VoicelineInteractTrigger : MonoBehaviour
{
    Inventory inv;
    [SerializeField]private Item item;
    [SerializeField]private int numOfItems;

    private void Start()
    {
        inv = Inventory.instance;
    }

    public void OnDestroy()
    {
        if(inv.getNumOfSpecificItemInInventory(item) == numOfItems)
        {
            Debug.Log("THAT SHOULD BE ENOUGH VOICELINE");
        }
    }



}
