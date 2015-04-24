using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSlot : MonoBehaviour, IPointerDownHandler, IDragHandler {

    public int index;
    public ItemU item;
    Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()//show icon in the character screen
    {
        if (item.itemType != ItemU.ItemType.None)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (inventory.draggingItem)
        {
            //head
            if (index == 0 && inventory.draggedItem.itemType == ItemU.ItemType.Head)
            {
                if (item.itemType != ItemU.ItemType.None)
                {
                    ItemU temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggedItem();
                }
                
            }

            //Armoure
            if (index == 1 && inventory.draggedItem.itemType == ItemU.ItemType.Armore)
            {
                if (item.itemType != ItemU.ItemType.None)
                {
                    ItemU temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggedItem();
                }
                
            }

            //Shose
            if (index == 2 && inventory.draggedItem.itemType == ItemU.ItemType.Shoes)
            {
                if (item.itemType != ItemU.ItemType.None)
                {
                    ItemU temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggedItem();
                }
                
            }

            //Trosers
            if (index == 3 && inventory.draggedItem.itemType == ItemU.ItemType.Trousers)
            {
                if (item.itemType != ItemU.ItemType.None)
                {
                    ItemU temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggedItem();
                }
                
            }

            //Gloves
            if (index == 4 && inventory.draggedItem.itemType == ItemU.ItemType.Gloves)
            {
                if (item.itemType != ItemU.ItemType.None)
                {
                    ItemU temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggedItem();
                }
                
            }

            //weapon
            if (index == 5 && inventory.draggedItem.itemType == ItemU.ItemType.Weapon)
            {
                if (item.itemType != ItemU.ItemType.None)
                {
                    ItemU temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.showDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.closeDraggedItem();
                }
                
            }
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (item.itemType != ItemU.ItemType.None)
        {
            inventory.draggedItem = item;
            inventory.showDraggedItem(item, -1);
            item = new ItemU();
        }
    }
}
