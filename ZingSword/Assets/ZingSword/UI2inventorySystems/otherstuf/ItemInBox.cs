using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInBox : MonoBehaviour, IPointerDownHandler {
    public ItemU item;
    public int index;
    Inventory invetory;
    DropBox dropbox;
	// Use this for initialization
	void Start () {
        invetory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dropbox = GameObject.FindGameObjectWithTag("DropBox").GetComponent<DropBox>();
	}
	
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log(invetory.ToString() + " itemInBox OnPointerDown method!");
        invetory.addExistingItem(item);
        Destroy(dropbox.listItemBox[index]);

        dropbox.listItemBox.RemoveAt(index);
        Destroy(dropbox.nearUs[index]);
        dropbox.nearUs.RemoveAt(index);

        dropbox.updateIndex();
    }
}
