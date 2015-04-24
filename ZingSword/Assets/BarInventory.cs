using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BarInventory : MonoBehaviour, IDragHandler, IPointerDownHandler {
    Inventory inventory;
    public ItemU item;
	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        /*if (item.itemType != ItemU.ItemType.None)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }*/
	}

    public void OnDrag(PointerEventData data)
    {
       /* if (item.itemType != ItemU.ItemType.None)
        {
            inventory.draggedItem = item;
            inventory.showDraggedItem(item, -1);
            item = new ItemU();
        }*/
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (inventory.draggingItem)
        {
            inventory.closeDraggedItem();
        }
    }
}
