using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler {

    public ItemU item; //sslot have to have a item
    Image itemImage;
    public int slotNumber; // index 0, gois to list items in inventory
    Inventory inventory;
    Text itemAmount;


	// Use this for initialization
	void Start () {
        itemAmount = gameObject.transform.GetChild(1).GetComponent<Text>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>(); //tag game object
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();   
	}
	
	// Update is called once per frame
	void Update () 
    {

        //if our item verible not empty, and image has to change
        if (inventory.Items[slotNumber].itemName != null)
        {
            itemAmount.enabled = false;
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;

            if (inventory.Items[slotNumber].itemType == ItemU.ItemType.Consumable)
            {
                itemAmount.enabled = true;
                itemAmount.text = "" + inventory.Items[slotNumber].itemValue;
            }
        }
        else
        {
            itemAmount.enabled = false;
            itemImage.enabled = false;
        }
	}

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Middle)//split comsumable ot item 
        {
            if (inventory.Items[slotNumber].itemValue > 1 && !inventory.draggingItem && inventory.Items[slotNumber].itemType == ItemU.ItemType.Consumable)
            {
                int temp = inventory.Items[slotNumber].itemValue / 2;
                ItemU split = new ItemU(inventory.Items[slotNumber].itemName, inventory.Items[slotNumber].itemId, inventory.Items[slotNumber].itemDesc, inventory.Items[slotNumber].itemPower, inventory.Items[slotNumber].itemSpeed, temp, inventory.Items[slotNumber].itemType);
                inventory.Items[slotNumber].itemType += temp;
                inventory.addItemAtEmptySlot(split);
            }
        }

        if (data.button == PointerEventData.InputButton.Right) //Drink the comcumble
        {
            if (inventory.Items[slotNumber].itemType == ItemU.ItemType.Consumable)
            {
                inventory.Items[slotNumber].itemValue--;
                if (inventory.Items[slotNumber].itemValue == 0)
                {
                    inventory.Items[slotNumber] = new ItemU();
                    itemAmount.enabled = false;
                    inventory.closeToolTip();
                }

            }
        }

        if (inventory.Items[slotNumber].itemName == null) // DRAG item from one slot to another
        {
            if (inventory.draggingItem)
            {
                inventory.Items[slotNumber] = inventory.draggedItem;
                inventory.closeDraggedItem();
            }
        }
        else
        {
            try
            {

                if (inventory.draggingItem)
                {
                    if (inventory.Items[slotNumber].itemName == inventory.draggedItem.itemName && inventory.draggedItem.itemType == ItemU.ItemType.Consumable)
                    {
                        int temp = inventory.Items[slotNumber].itemValue;
                        inventory.Items[slotNumber] = new ItemU(inventory.draggedItem.itemName, inventory.draggedItem.itemId, inventory.draggedItem.itemDesc, inventory.draggedItem.itemPower, inventory.draggedItem.itemSpeed, inventory.draggedItem.itemValue + temp, inventory.draggedItem.itemType);
                        inventory.closeDraggedItem();
                    }

                    if (inventory.Items[slotNumber].itemName != null)
                    {
                        inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
                        inventory.Items[slotNumber] = inventory.draggedItem;
                        inventory.closeDraggedItem();
                    }
                }
            }
            catch { }
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (inventory.Items[slotNumber].itemName != null && !inventory.draggingItem)
        {
            inventory.showToolTip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
            
        }
            
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].itemName != null)
        {
            inventory.closeToolTip();
        }
    }

    public void OnDrag(PointerEventData data)
    {

        if (!inventory.draggingItem && data.button == PointerEventData.InputButton.Left)
        {
            if(inventory.Items[slotNumber].itemType == ItemU.ItemType.Consumable)
            {
                inventory.Items[slotNumber].itemValue++;
            }
            if (inventory.Items[slotNumber].itemName != null)
            {
                inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
                inventory.Items[slotNumber] = new ItemU();
                itemAmount.enabled = false;
            }
        }
    }
}
