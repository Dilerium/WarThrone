using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<ItemU> items = new List<ItemU>();

	// Use this for initialization
	void Start () 
    {
        //Helmets
        items.Add(new ItemU("PaladinHat", 0, "Metal helmet", 10, 10, 1, ItemU.ItemType.Head));
        items.Add(new ItemU("HeavyHat", 1, "Metal helmet", 10, 10, 1, ItemU.ItemType.Head));
        items.Add(new ItemU("NormalHat", 3, "Metal helmet", 10, 10, 1, ItemU.ItemType.Head));
          
        //Armore
        items.Add(new ItemU("DragonArmore", 4, "Metal helmet", 10, 10, 1, ItemU.ItemType.Armore));
        items.Add(new ItemU("HeavyArmore", 5, "Metal helmet", 10, 10, 1, ItemU.ItemType.Armore));
        items.Add(new ItemU("NormalArmore", 6, "Metal helmet", 10, 10, 1, ItemU.ItemType.Armore));
       
        //Shoes
        items.Add(new ItemU("DragonShoes", 7, "Metal helmet", 10, 10, 1, ItemU.ItemType.Shoes));
        items.Add(new ItemU("HeavyShoes", 8, "Metal helmet", 10, 10, 1, ItemU.ItemType.Shoes));
        items.Add(new ItemU("NormalShoes", 9, "Metal helmet", 10, 10, 1, ItemU.ItemType.Shoes));
       
        //Gloves
        items.Add(new ItemU("DragonGloves", 10, "Metal helmet", 10, 10, 1, ItemU.ItemType.Gloves));
        items.Add(new ItemU("HeavyGloves", 11, "Metal helmet", 10, 10, 1, ItemU.ItemType.Gloves));
        items.Add(new ItemU("NormalGloves", 12, "Metal helmet", 10, 10, 1, ItemU.ItemType.Gloves));
       
        //Swords
        items.Add(new ItemU("ChristalSword", 13, "Sword made of Christal", 10, 10, 1, ItemU.ItemType.Weapon));
        items.Add(new ItemU("DragonSword", 14, "Sword made of Dragon bone", 10, 10, 1, ItemU.ItemType.Weapon));

        //Bows
        items.Add(new ItemU("Bow", 15, "Sword made of Dragon bone", 10, 10, 1, ItemU.ItemType.Bow));
        items.Add(new ItemU("ChristalBow", 16, "Sword made of Christal", 10, 10, 1, ItemU.ItemType.Bow));
        items.Add(new ItemU("DragonBow", 17, "Sword made of Dragon bone", 10, 10, 1, ItemU.ItemType.Bow));

        //Food
        items.Add(new ItemU("GreenApple", 18, "Sword made of Dragon bone", 10, 10, 1, ItemU.ItemType.Food));
        items.Add(new ItemU("RedApple", 19, "Sword made of Dragon bone", 10, 10, 1, ItemU.ItemType.Food));
        items.Add(new ItemU("Nat", 20, "Sword made of Dragon bone", 10, 10, 1, ItemU.ItemType.Food));
        
        //Potions
        items.Add(new ItemU("BigHealthPotion", 21, "HP", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("BigStaminaPotion", 22, "ST", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("SmallHealthPotion", 23, "HP", 10, 10, 1, ItemU.ItemType.Consumable));
        items.Add(new ItemU("SmallStaminaPotion", 24, "HP", 10, 10, 1, ItemU.ItemType.Consumable));
    }
}

