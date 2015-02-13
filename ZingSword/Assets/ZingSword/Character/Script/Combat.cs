using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

	public GameObject opponent;
	public AnimationClip attack;

	public int damage; //damage from player 
	public double impactTime; //get the % or oprocs time from animation to get a progress in game
	public bool impacted;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if player press the space bar play attack animation
		if(Input.GetKey (KeyCode.Space))
	    {
			animation.Play(attack.name);
			ClickToMoveCharControll.attack = true;

			//if there is mobs in range, while press attack
			//player will transform uppon to anemy
			//to hit him
			if(opponent!=null)
			{
				transform.LookAt(opponent.transform.position);
			}
		}
		if (!animation.IsPlaying (attack.name)) 
		{
			ClickToMoveCharControll.attack = false;
			impacted = false;
		}
		impact ();
	}

	//battle script to take a damage
	void impact()
	{
		if (opponent != null && animation.IsPlaying (attack.name) && !impacted) 
		{
			//if we have reach impacted time, we going to hit our opponent
			if ((animation [attack.name].time) > (animation [attack.name].length * impactTime)) 
			{
				opponent.GetComponent<Mob> ().getHit (damage);
				impacted = true;
			}
		}
	}
}