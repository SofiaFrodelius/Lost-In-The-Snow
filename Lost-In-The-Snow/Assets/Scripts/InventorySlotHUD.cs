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
    [SerializeField]
    private Text numOfItemsInSlot;

    private Item currentItem;
    private Vector3 previousPosition;
    IEnumerator currentCoroutine;

    public void Awake()
    {
        itemDescription.enabled = false;
        itemName.enabled = false;
    }


    public void updateSlot(Item item, int test)
    {
        itemImage.enabled = true;
        currentItem = item;
        itemImage.sprite = item.getImage();
        itemDescription.text = item.getDescription();
        itemName.text = item.getName();

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = previewSlot(0.5f);
        StartCoroutine(currentCoroutine);

        Debug.Log(test);
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
        //tempkod
        if (eventData.pointerCurrentRaycast.gameObject == eventData.pointerPressRaycast.gameObject) Debug.Log("Same inventory slot");
        else Debug.Log("Different inventory slot");
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemImage.rectTransform.position = eventData.position;
    }


    IEnumerator previewSlot(float time)
    {
        float previousAlpha = itemImage.color.a;

        for(float f = 0; f < 1.0f; f += Time.deltaTime / time)
        {
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, Mathf.Lerp(previousAlpha, 1.0f, f));
            yield return null;
        }

        previousAlpha = itemImage.color.a;
        yield return new WaitForSeconds(2.5f);

        for (float f = 0; f < 1.0f; f += Time.deltaTime / time)
        {
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, Mathf.Lerp(previousAlpha, 0.0f, f));
            yield return null;
        }
        currentCoroutine = null;
    }
}
