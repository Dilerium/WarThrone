using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GuiGenerator : MonoBehaviour 
{
	private Player char1;
	private const int STARTING_POINTS = 50;
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
	void Start () 
	{
		char1 = new Player ("Person");
		char1.addStats (STARTING_POINTS);
		stats = GameObject.FindGameObjectWithTag ("Stats");
		stats.SetActive (false);
		addStr = (Button) GameObject.FindGameObjectWithTag ("addStr").GetComponent<Button> ();
		addStr.enabled = false;
		/*lowerStr.SetActive (false);
		addSpd.SetActive (false);
		lowerSpd.SetActive (false);
		addHealth.SetActive (false);
		lowerHealth.SetActive (false);
		addStam.SetActive (false);
		lowerStam.SetActive (false);
		addDef.SetActive (false);
		lowerDef.SetActive (false);*/
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.C))
		{
			show = !show;
			stats.SetActive(show);
		}
		if (show)
		{
			/*if(char1.getStats () > 0)
			{
				addStr.interactable = true;
				lowerStr.interactable = true;
				addSpd.interactable = true;
				lowerSpd.interactable = true;
				addHealth.interactable = true;
				lowerHealth.interactable = true;
				addStam.interactable = true;
				lowerStam.interactable = true;
				addDef.interactable = true;
				lowerDef.interactable = true;
			}*/
			playerName.text = char1.getName ();
			remainingPoints.text = char1.getStats ().ToString ();
			currStrength.text = char1.getStrength ().ToString ();
			currSpeed.text = char1.getSpeed().ToString ();
			currHealth.text = char1.getHealth().ToString ();
			currStamina.text = char1.getStamina().ToString ();
			currDefence.text = char1.getDefence().ToString ();
			GameObject.FindGameObjectWithTag ("addStr").GetComponent<Button>().enabled = true;
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
		GUI.Label (new Rect(10,10, 50,25), "Name");
		GUI.TextArea (new Rect (65, 10, 100, 25), char1.getName ());
	}

	private void DisplayAttribute()
	{
		for(int i=0; i < char1.getAttributes().Length; i++){
			GUI.Label(new Rect(10, 40 + (i* 25), 100, 25), char1.getAttributes ().GetValue (i).ToString ());
			Button newButton = UnityEngine.Resources.Load<Button>("UnityEngine/UI/Button");
			//newButton.guiText.text = "+";
			newButton.onClick.AddListener (delegate{char1.increaseStat(1, char1.getAttributes ().GetValue (i).ToString ());});
			Button newButton2 = UnityEngine.Resources.Load<Button>("UnityEngine/UI/Button");
			//newButton2.guiText.text = "-";
			newButton2.onClick.AddListener (delegate{char1.increaseStat(-1, char1.getAttributes ().GetValue (i).ToString ());});
		}
	}

	private void DisplayPointsLeft()
	{
		GUI.Label (new Rect(250,10, 100,25), "Points left : " + char1.getStats());
	}
}