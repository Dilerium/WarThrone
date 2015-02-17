using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<ItemU> items = new List<ItemU>();

	// Use this for initialization
	void Start () 
    {
        items.Add(new ItemU("sword01", 0, "Gold Sword", 10, 10, 1, ItemU.ItemType.Weapon));
        items.Add(new ItemU("sword02", 1, "better sword 2", 10, 10, 1, ItemU.ItemType.Weapon));
        items.Add(new ItemU("potion01", 2, "Heaaalth", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("sword03", 3, "Nice sword 3", 10, 10, 1, ItemU.ItemType.Weapon));
        items.Add(new ItemU("helmet01", 4, "Nice helmet", 10, 10, 1, ItemU.ItemType.Armore));
        items.Add(new ItemU("gloves01", 5, "Nice gloves", 10, 10, 1, ItemU.ItemType.Armore));
        items.Add(new ItemU("potion02", 6, "maaanaaaa", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("potion03", 7, "poisooon", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("potion04", 8, "woter", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("food03", 9, "apple", 10, 10, 1, ItemU.ItemType.Consumable));
	}
}

