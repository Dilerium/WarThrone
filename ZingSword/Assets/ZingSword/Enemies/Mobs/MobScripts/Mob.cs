using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	public float speed;
	public float range;
	public CharacterController controller;
	public Transform player;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip attack;
	public AnimationClip die;

	private int health;


	// Use this for initialization
	void Start () 
	{
		health = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!inRange ()) 
		{
			chase ();		
		} 
		else 
		{
			animation.CrossFade(idle.name);
		}
		Debug.Log (health);
	}



	bool inRange()
	{
		//if distance between the position of our enemy and position of our player
		//is less than in range of the map return true and attack
		if (Vector3.Distance(transform.position, player.position) < range) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	//HEALTH controling, geing damage and minus from full health 
	public void getHit(int damage)
	{
		health = health - damage;
		if (health <= 0) 
		{
			health = 0;
			//player.animation.Play(die.name);
		}
	}

	//method for controlling transforms for emeny to look at player
	void chase()
	{
		//look at Player
		transform.LookAt (player.position);
		//transform upon to player
		controller.SimpleMove (transform.forward * speed);
		animation.CrossFade (run.name);
	}

	void OnMouseOver()
	{
		player.GetComponent<Combat> ().opponent = gameObject;
	}
}
