using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldableInventorySlotHUD : MonoBehaviour
{
    private Item currentItem;
    [SerializeField]
    private Image itemImage;

    public void Start()
    {

    }


    public void updateSlot(Item item)
    {
        Debug.Log(item);
        currentItem = item;
        itemImage.sprite = item.getImage();
        itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 1);
    }
}
