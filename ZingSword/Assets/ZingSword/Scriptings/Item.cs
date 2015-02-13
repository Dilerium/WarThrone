using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	public string itemType;
	public Texture3D worldTexture;
	public Texture2D inventoryTexture;
	public int value;
	public int movementMod;

	// Use this for initialization
	void Start () {
	
	}

	public Item(string itemType, Texture3D worldTexture, Texture2D inventoryTexture, int value, int movementMod){
		this.itemType = itemType;
		this.worldTexture = worldTexture;
		this.inventoryTexture = inventoryTexture;
		this.value = value;
		this.movementMod = movementMod;
	}

	public int getValue(){
		return this.value;
	}

	public Texture2D get2DTexture(){
		return this.inventoryTexture;
	}

	public Texture3D get3DTexture(){
		return this.worldTexture;
	}

	public string getItemType(){
		return this.itemType;
	}

	public int getMovementMod(){
		return this.movementMod;
	}
}