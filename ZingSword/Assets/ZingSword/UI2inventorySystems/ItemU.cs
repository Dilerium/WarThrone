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
        //GameObject slot = Instantiate(Resources.Load<GameObject>("ItemDatabase"));
        //itemIcon = Resources.Load<Sprite>("Assets/ZingSword/UI2inventorySystems/Resources " + name);
       // itemIcon = Resources.Load<Sprite>("Assets/ZingSword/UI2inventorySystems/Resources/" + name);
      
        itemName = name;
        itemId = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Sprite>("Assets/ZingSword/UI2inventorySystems/Resources/" + name);
        itemSpeed = speed;
        itemPower = power;
        itemValue = value;
        itemType = type;
        itemModel = Resources.Load<GameObject>("DroppedItem");
    }

    public ItemU()
    {

    }


}
