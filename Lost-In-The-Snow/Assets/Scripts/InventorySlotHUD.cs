using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlotHUD : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IDragHandler
{
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private Text itemDescription;
    [SerializeField]
    private Text itemName;

    private Item currentItem;
    private Vector3 previousPosition;

    public void Awake()
    {
        itemDescription.enabled = false;
        itemName.enabled = false;
    }


    public void updateSlot(Item item)
    {
        Debug.Log("Added");
        itemImage.enabled = true;
        currentItem = item;
        itemImage.sprite = item.getImage();
        itemDescription.text = item.getDescription();
        itemName.text = item.getName();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemDescription.enabled = true;
        itemName.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemDescription.enabled = false;
        itemName.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        previousPosition = itemImage.rectTransform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        itemImage.rectTransform.position = previousPosition;
        if (eventData.pointerCurrentRaycast.gameObject == eventData.pointerPressRaycast.gameObject) Debug.Log("Same inventory slot");
        else Debug.Log("Different inventory slot");
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemImage.rectTransform.position = eventData.position;
    }




}
