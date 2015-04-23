using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour 
{
	public float speed = 2;
	public CharacterController controller;
	public Player player;
	public Terrain terrain;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip attack;
	public AnimationClip die;

	private int id;
	private int health;
	private int strength;
	private bool hasMoved = false;

	public Mob()
	{

	}

	public Mob(Vector3 startPosition)
	{

	}

	// Use this for initialization
	void awake()
	{
		this.health = 100;
		this.strength = 5;
	}

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (inSight ())
		{
			Debug.Log ("You are being chased, zomg RUNAWAY!");
			// If enemy has player in sight it should approach the player.
			chase ();
		}
		else if(inRange ())
		{
			// if enemy has player in range it should attack the player.
			doAttack ();
		}
		else if(Vector3.Distance (this.transform.position, EnemySpawn.getSpawn(this.id)) > 1)
		{
				Debug.Log ("An enemy is returning to there post!");
				returnToPost();
		}
		else
		{
			Debug.Log ("Enemy is idle... STAB HIM!");
			animation.CrossFade(idle.name);
		}
	}

	bool inSight()
	{
		//if distance between the position of our enemy and position of our player
		//is less than given value return true
		if (Vector3.Distance(this.transform.position, player.transform.position) < 15 && Vector3.Distance(this.transform.position, player.transform.position) > 2) 
		{
			return true;
		} 
		else
		{
			return false;
		}
	}

	bool inRange()
	{
		if (Vector3.Distance (this.transform.position, player.transform.position) < 3)
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

	void returnToPost()
	{
		this.transform.LookAt (EnemySpawn.getSpawn(this.id));
		controller.SimpleMove (this.transform.forward * speed);
		animation.CrossFade (run.name);
	}

	//method for controlling transforms for emeny to look at player
	void chase()
	{
		//look at Player
		this.transform.LookAt (player.transform.position);
		//transform upon to player
		controller.SimpleMove (this.transform.forward * speed);
		animation.CrossFade (run.name);
	}

	void OnMouseOver()
	{
		player.GetComponent<Combat> ().opponent = gameObject;
	}

	void doAttack()
	{
		animation.CrossFade (attack.name);
		player.takeDamage (20);
	}

	public int getId()
	{
		return this.id;
	}

	public void setId(int newId)
	{
		this.id = newId;
	}

	public string getName()
	{
		return name;
	}

	public void setName(string newName)
	{
		name = newName;
	}
}