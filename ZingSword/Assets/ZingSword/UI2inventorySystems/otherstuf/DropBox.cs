using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DropBox : MonoBehaviour, IPointerDownHandler {

    Inventory inventory;
    public GameObject[] droppedItem;
    public List <GameObject> nearUs = new List<GameObject>();
    public GameObject itemBox;
    public List<GameObject> listItemBox = new List<GameObject>();

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	
	}
	
	// Update is called once per frame
	void Update () {
        droppedItem = GameObject.FindGameObjectsWithTag("Item");
        getDroppedItemsInRange();
        checkIfItemStillInRange();

	}

    public void updateIndex()
    {
        for (int i = 0; i < listItemBox.Count; i++)
        {
            listItemBox[i].GetComponent<ItemInBox>().index = i;
        }
    }

    void createItemsInBox()
    {
        //145
        Vector3 posi = new Vector3(0, (-55 * listItemBox.Count) + 145, 0);
        GameObject item = (GameObject)Instantiate(itemBox);

        ItemInBox boxWithItem = item.GetComponent<ItemInBox>();
        boxWithItem.index = listItemBox.Count;
        boxWithItem.item = nearUs[listItemBox.Count].GetComponent<DroppedItem>().item;

        listItemBox.Add(item);
        item.transform.parent = this.gameObject.transform;

        item.GetComponent<RectTransform>().localPosition = posi;

        item.transform.GetChild(0).GetComponent<Image>().sprite = nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemIcon;
        item.transform.GetChild(1).GetComponent<Text>().text = nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemName;
        if (nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemType == ItemU.ItemType.Consumable)
        {
            item.transform.GetChild(2).GetComponent<Text>().enabled = true;
            item.transform.GetChild(2).GetComponent<Text>().text = "x" + nearUs[listItemBox.Count - 1].GetComponent<DroppedItem>().item.itemValue;
        }
    }

    void UppdateItemBoxPosition()
    {
        for (int i = 0; i < listItemBox.Count; i++)
        {
            Vector3 posi = new Vector3(0, (-55 * i) + 110, 0);
            listItemBox[i].GetComponent<RectTransform>().localPosition = posi;
        }
    }

    void checkIfItemStillInRange()
    {
        for (int i = 0; i < nearUs.Count; i++)
        {
            float distance = 100000000;
            if (nearUs[i] != null)
                distance = Vector3.Distance(nearUs[i].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            if(distance > 3)
            {
                Destroy(listItemBox[i]);
                listItemBox.RemoveAt(i);
                nearUs.RemoveAt(i);
                UppdateItemBoxPosition();
            }
        }
    }

    void getDroppedItemsInRange()
    {
        for (int i = 0; i < droppedItem.Length; i++)
        {
            float distance = Vector3.Distance(droppedItem[i].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            Debug.Log(distance);
            if (distance <= 3)
            {
                ItemU item = droppedItem[i].GetComponent<DroppedItem>().item;
                if (nearUs.Count == 0)
                {
                    nearUs.Add(droppedItem[i]);
                    //create item box in box
                    createItemsInBox();
                }
                else
                {
                    bool temp = false;
                    for (int k = 0; k < nearUs.Count; k++)
                    {
                        if(nearUs[k] != null)
                        {
                            if (nearUs[k].GetComponent<DroppedItem>().item.Equals(item))
                            {
                                temp = true;
                            }
                            if (!temp && k == nearUs.Count - 1)
                            {
                                nearUs.Add(droppedItem[i]);
                                //create item box in the box
                                createItemsInBox();
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (inventory.draggingItem)
        {
            dropItem(inventory.draggedItem);
            inventory.closeDraggedItem();
        }
    }

    public void dropItem(ItemU item) // instanciate an item.
    {
        try
        {
            GameObject itemAsGameObject = (GameObject)Instantiate(item.itemModel, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
            itemAsGameObject.GetComponent<DroppedItem>().item = item;
        }
        catch { }
    }
}
