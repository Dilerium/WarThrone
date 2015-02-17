using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //manage our slots
    public List<GameObject> Slots = new List<GameObject>();
    public List<ItemU> Items = new List<ItemU>();
    ItemDatabase database;
    public GameObject slots;
    int x = -110;
    int y = 135;
    public GameObject tooltip;
    public GameObject draggedItemGameObject;
    public bool draggingItem = false;
    public ItemU draggedItem;
    public int indexOfDraggedItem;


    void Update()
    {
        if (draggingItem)
        {
            Vector3 posi = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
            draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(posi.x + 15, posi.y - 15, posi.z);
        }
    }
    //tooltip
    public void showToolTip(Vector3 toolPosition, ItemU item)
    {
        tooltip.SetActive(true);
        tooltip.GetComponent<RectTransform>().localPosition = new Vector3(toolPosition.x + 250, toolPosition.y, toolPosition.z);//nessesary chake

        tooltip.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        tooltip.transform.GetChild(2).GetComponent<Text>().text = item.itemDesc;
    }

    public void showDraggedItem(ItemU item, int slotnumber)
    {
        indexOfDraggedItem = slotnumber;
        closeToolTip();
        draggedItemGameObject.SetActive(true);
        draggedItem = item;
        draggingItem = true;
        draggedItemGameObject.GetComponent<Image>().sprite = item.itemIcon;
    }

    public void closeDraggedItem()
    {
        draggedItem = new ItemU();
        draggedItemGameObject.SetActive(false);
        draggingItem = false;
    }

    public void closeToolTip()
    {
        tooltip.SetActive(false);
    }

	// Use this for initialization
	void Start () 
    {

        int Slotamount = 0;
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();//access to database and get item from it
        for (int i = 1; i < 6; i++)
        {
            for (int k = 1; k < 6; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);//this slot are child of current object
                slot.GetComponent<SlotScript>().slotNumber = Slotamount;
                Slots.Add(slot);
                Items.Add(new ItemU());
                slot.transform.parent = this.gameObject.transform;
                slot.name = "Slot" + i + "." + k;

                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 55;
                if (k == 5)
                {
                    x = -110;
                    y = y - 55;
                }
                Slotamount++;
            }
        }
        addItem(1);
        addItem(0);
        addItem(2);        
        addItem(5);
        addItem(5);
        addItem(5);
        addItem(5);
	}

    public void checkIfItemExist(int itemID, ItemU item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemId == itemID)
            {
                Items[i].itemValue = Items[i].itemValue + item.itemValue;
                break;
            }
            else if(i == Items.Count - 1)
            {
                addItemAtEmptySlot(item);
            }
        }
    }

    public void addExistingItem(ItemU item)
    {
        if (item.itemType == ItemU.ItemType.Consumable)
        {
            checkIfItemExist(item.itemId, item);
        }
        else
        {
            addItemAtEmptySlot(item);
        }
    }

    void addItem(int id)
    {
        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i].itemId == id)//point ****
            {
                ItemU item = database.items[i];

                if (database.items[i].itemType == ItemU.ItemType.Consumable)
                {
                    //check if item exist

                    checkIfItemExist(id, item);
                    break;
                }
                else
                {
                    addItemAtEmptySlot(item);
                }


               // Item newItem = new Item(item.itemName, item.itemId, item.itemDesc, item.itemPower, item.itemSpeed, item.itemValue, item.itemType);
                //addItemAtEmptySlot(item);
                //break;
            }
        }

    }

    public void addItemAtEmptySlot(ItemU item)
    {
        Debug.Log(Items[0].itemName);
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == null)
            {
                Items[i] = item;
                break;
            }
        }

    }
}
