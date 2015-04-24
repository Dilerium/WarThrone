using UnityEngine;
using System.Collections;

[System.Serializable]

public class ItemU {

    public string itemName;
    public int itemId;
    public string itemDesc;
    public Sprite itemIcon;
    public GameObject itemModel;
    public int itemPower;
    public int itemSpeed;
    public int itemValue;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Quest,
        Head,
        Shoes,
        Trousers,
        Gloves,
        Armore,
        Rings,
        Necklace,
		None
    }

    public ItemU(string name, int id, string desc, int speed, int power, int value, ItemType type)
    {
        itemName = name;
        itemId = id;
        itemDesc = desc;
        itemSpeed = speed;
        itemPower = power;
        itemValue = value;
        itemType = type;
        itemIcon = Resources.Load<Sprite>("" + name);
        itemModel = Resources.Load<GameObject>("DroppedItem");
    }

    public ItemU()
    {

    }

    public string ToString()
    {
        return this.itemName;
    }
}
