﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
	public AnimationClip die;
	public bool dying = false;
	public bool dead = false;

	private string charName;
	private string primaryAttribute;
	private int strength;
	private int speed;
    //healt defs
	private int health;
    public Scrollbar HealthBar;
	private int currHealth;
	private int maxHealth;
    //end of health defs
	private int stamina;
	private int defence;
	private int level; 
	private int exp;
	private int maxExp = 100;
	private int attack;
	private int armour;
	private int statPoints;
	private Item equippedWeapon;
	private Item equippedHelm;
	private Item equippedArmour;
	private Item equippedBracer;
	private Item equippedLeggings;
	private Item equippedBoots;
	private Item[] inventoryGear = new Item[6];
	private Item[] inventoryHealth = new Item[3];
	private Item[] inventoryAttack = new Item[3];
	private Item[] inventoryDefence = new Item[3];
	private System.Array Attributes = Enum.GetValues(typeof(AttributeName));

	public enum AttributeName
	{
		Strength,
		Speed,
		Health,
		Stamina,
		Defence
	}
	
	public void Start()
	{
		this.charName = "Aegnor";
		initialize ();
	}
	
	void Update()
	{
		if(animation[die.name].time > 2)
		{
			dead = true;
			dying = false;
		}
		else if(dying && !dead)
		{
			animation.Play (die.name);
			GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCamera>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().enabled = false;
		}
		else
		{

		}
	}

	public void initialize()
	{
		this.setHealth (5);
		this.setStrength (5);
		this.setDefence (5);
		this.setSpeed (5);
		this.setStamina (5);
		this.statPoints = 0;
		this.level = 1;
	}

	public Player()
	{

	}

	public void awake()
	{

	}

	public Player(string name)
	{
		this.charName = name;
		this.strength = 5;
		this.speed = 5;
		this.health = 5; //Health Bar
		this.stamina = 5;
		this.defence = 5;
		this.level = 1;
		this.exp = 0;
		this.attack = (strength * 4);
		this.armour = (int) (defence * 3);
	}

	public Player (string name, int strength, int speed, int health, int stamina, int defence, int level, int exp)
	{
		this.charName = name;
		this.strength = strength;
		this.speed = speed;
		this.health = health;// Health in float
		this.stamina = stamina;
		this.defence = defence;
		this.level = level;
		this.exp = exp;
		this.attack = (strength * 4);
		this.armour = (int) (defence * 3);
	}

	public void setPrimaryAttribute(string primaryAttribute)
	{
		this.primaryAttribute = primaryAttribute;
	}
	
	public string getPrimaryAttribute()
	{
		return this.primaryAttribute;
	}
	
	public System.Array getAttributes()
	{
		return this.Attributes;
	}
	
	public void addAttributes(int pointChange)
	{
		this.statPoints += pointChange;
	}

	public void increaseStat(int value, string attribute)
	{
		switch (attribute) 
		{
			case "Strength":
				setStrength (value);
				break;
			case "Speed":
				setSpeed (value);
				break;
			case "Health":
				setHealth (value);
				break;
			case "Stamina":
				setStamina (value);
				break;
			case "Defence":
				setDefence (value);
				break;
		}
	}

	public string getName()
	{
		return this.charName;
	}

	public void setStrength(int gain)
	{
		this.strength += gain;
		this.attack = (strength * 4);
		this.statPoints -= gain;
	}

	public int getStrength()
	{
		return this.strength;
	}

	public int getAttack()
	{
		return this.attack;
	}

	public void boostAttack(Item item)
	{
		this.attack += item.getValue ();
	}

	public void setSpeed(int gain)
	{
		this.speed += gain;
		this.statPoints -= gain;
	}

	public int getSpeed()
	{
		return this.speed;
	}

	public void setHealth(int gain)
	{
		this.health += gain;
		this.maxHealth = (health * 8);
		this.currHealth = this.maxHealth;
		this.statPoints -= gain;
	}

	public int getHealth()
	{
		return this.health;
	}

	public void recoverHealth(Item item)
	{
		currHealth += item.getValue ();
	}

	public int getCurrHealth()
	{
		return this.currHealth;
	}

	public void setDefence(int gain)
	{
		this.defence += gain;
		this.armour = (int)(defence * 1.5);
		this.statPoints -= gain;
	}

	public int getDefence()
	{
		return this.defence;
	}

	public int getArmour()
	{
		return this.armour;
	}

	public void boostArmour(Item item)
	{
		this.armour += item.getValue ();
	}

	public void setStamina(int gain)
	{
		this.stamina += gain;
		this.statPoints -= gain;
	}

	public int getStamina()
	{
		return this.stamina;
	}

	public int getStats()
	{
		return this.statPoints;
	}

	public void setExp(int exp)
	{
		this.exp += exp;
		if (this.exp >= maxExp) 
		{
			int tempExp = (this.exp - maxExp);
			this.levelUp();
			this.setExp (tempExp);
		}
	}

	public void levelUp()
	{
		this.level += 1;
		this.addAttributes (5);
		this.maxExp = (int) (maxExp * 1.15);
		this.exp = 0;//Had a problem with a cast missing exception when using "maxExp *= 1.15;"
	}

	public int getLevel()
	{
		return this.level;
	}

	public void takeDamage(int damage)
	{
		int dealtDamage = (damage - armour);
		this.currHealth -= (dealtDamage > 0) ? dealtDamage : 1;
        this.HealthBar.size = health / 100f;
		if(this.currHealth <= 0) {  this.dying = true; }
		Debug.Log ("Player : " + this.currHealth);
	}

	public void useItem(Item item)
	{
		switch (item.getItemType()) 
		{
			case "weapon":
				this.equippedWeapon = item;
				break;
			case "armour":
				this.equippedArmour = item;
				break;
			case "bracer":
				this.equippedBracer = item;
				break;
			case "leggings":
				this.equippedLeggings = item;
				break;
			case "helm":
				this.equippedHelm = item;
				break;
			case "boots":
				this.equippedBoots = item;
				break;
			case "hPotion":
				this.recoverHealth(item);
				break;
			case "aPotion":
				this.boostAttack(item);
				break;
			case "dPotion":
				this.boostArmour(item);
				break;
		}
	}

	public bool isDying()
	{
		return dying;
	}

	public bool isDead()
	{
		return dead;
	}
}