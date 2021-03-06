﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))] ///// REQUIRE

public class GuiGenerator : MonoBehaviour 
{
	public Player char1;
	private const int STARTING_POINTS = 10;
	private bool show = false;
	public Text currStrength;
	public Text currSpeed;
	public Text currHealth;
	public Text currStamina;
	public Text currDefence;
	public Text playerName;
	public Text remainingPoints;
	private Button addStr;
	private Button lowerStr;
	private Button addSpd;
	private Button lowerSpd;
	private Button addHealth;
	private Button lowerHealth;
	private Button addStam;
	private Button lowerStam;
	private Button addDef;
	private Button lowerDef;
	private GameObject stats;
	// Use this for initialization

    Inventory inventoryScript; //instantiate ///// REQUIRE
    GameObject inventory; ///// REQUIRE
    bool showInventory = false; ///// REQUIRE*/

	void Start () 
	{
		try
		{
			char1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			char1.addAttributes (STARTING_POINTS);
			stats = GameObject.FindGameObjectWithTag ("Stats");
			stats.SetActive (false);
		}
		catch(Exception e)
		{
			Debug.Log (e.StackTrace);
		}

		try
		{
			inventory = GameObject.FindGameObjectWithTag("Canvas");///// REQUIRE
			inventoryScript = inventory.GetComponent<Inventory> (); ///// REQUIRE
			inventory.SetActive(false);///// REQUIRE*/
		}
		catch(Exception e)
		{
			Debug.Log (e.StackTrace);
		}
	}

	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown("i")) // activate inventory
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
            //method to remove the list of items from drop box 
        }

        //important for project part, when i click to item
        //if this item that we klick by MAUSE in our RANGE
        if (Input.GetMouseButtonDown(0))
        {
            // if mouse view in range to take an item
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                float distance = Vector3.Distance(hit.transform.position, this.transform.position);
                //Debug.Log(distance);

                if (hit.transform.tag == "Item" && distance <= 3)
                {
                    //Debug.Log("hit");
                    inventoryScript.addExistingItem(hit.transform.GetComponent<DroppedItem>().item);
                    Destroy(hit.transform.gameObject);

                }///// REQUIRE
            }///// REQUIRE
        }///// REQUIRE*/

		if (Input.GetKeyDown("c"))
		{
			show = !show;
			stats.SetActive(show);
		}

		if (show)
		{
			foreach (Button btn in stats.GetComponentsInChildren<Button>())
			{
				btn.enabled = true;
			}
			playerName.text = char1.getName ();
			remainingPoints.text = char1.getStats ().ToString ();
			if(char1.getStats () < 1)
			{
				GameObject.FindGameObjectWithTag ("addStr").GetComponent<Button>().enabled = false;
				GameObject.FindGameObjectWithTag ("addSpd").GetComponent<Button>().enabled = false;
				GameObject.FindGameObjectWithTag ("addHealth").GetComponent<Button>().enabled = false;
				GameObject.FindGameObjectWithTag ("addStam").GetComponent<Button>().enabled = false;
				GameObject.FindGameObjectWithTag ("addDef").GetComponent<Button>().enabled = false;
			}
			currStrength.text = char1.getStrength ().ToString ();
			if(Int32.Parse(char1.tempStr.text) < 1)
			{
				GameObject.FindGameObjectWithTag("lowerStr").GetComponent<Button>().enabled = false;
			}
			currSpeed.text = char1.getSpeed().ToString ();
			if(Int32.Parse(char1.tempSpd.text) < 1)
			{
				GameObject.FindGameObjectWithTag("lowerSpd").GetComponent<Button>().enabled = false;
			}
			currHealth.text = char1.getHealth().ToString ();
			if(Int32.Parse(char1.tempHealth.text) < 1)
			{
				GameObject.FindGameObjectWithTag("lowerHealth").GetComponent<Button>().enabled = false;
			}
			currStamina.text = char1.getStamina().ToString ();
			if(Int32.Parse(char1.tempStam.text) < 1)
			{
				GameObject.FindGameObjectWithTag("lowerStam").GetComponent<Button>().enabled = false;
			}
			currDefence.text = char1.getDefence().ToString ();
			if(Int32.Parse(char1.tempDef.text) < 1)
			{
				GameObject.FindGameObjectWithTag("lowerDef").GetComponent<Button>().enabled = false;
			}
		}
	}

	void OnGUI()
	{
		/*if (show) 
		{
			DisplayName ();
			DisplayAttribute ();
			DisplayPointsLeft ();
		}*/
	}

	private void DisplayName()
	{
		//GUI.Label (new Rect(10,10, 50,25), "Name");
		//GUI.TextArea (new Rect (65, 10, 100, 25), char1.getName ());
	}

	private void DisplayAttribute()
	{
		/*for(int i=0; i < char1.getAttributes().Length; i++){
			GUI.Label(new Rect(10, 40 + (i* 25), 100, 25), char1.getAttributes ().GetValue (i).ToString ());
			Button newButton = UnityEngine.Resources.Load<Button>("UnityEngine/UI/Button");
			//newButton.guiText.text = "+";
			newButton.onClick.AddListener (delegate{char1.increaseStat(1, char1.getAttributes ().GetValue (i).ToString ());});
			Button newButton2 = UnityEngine.Resources.Load<Button>("UnityEngine/UI/Button");
			//newButton2.guiText.text = "-";
			newButton2.onClick.AddListener (delegate{char1.increaseStat(-1, char1.getAttributes ().GetValue (i).ToString ());});
		}*/
	}

	private void DisplayPointsLeft()
	{
		//GUI.Label (new Rect(250,10, 100,25), "Points left : " + char1.getStats());
	}
}