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
	private int defense;
	private int despawnTime;
	private bool dying = false;
	private bool dead = false;

	public Mob()
	{

	}

	public Mob(Vector3 startPosition)
	{

	}

	// Use this for initialization
	void awake()
	{
		
	}

	void Start () 
	{
		this.health = (player.getLevel () > 1) ? (100 * (player.getLevel ()/2)) : 50;
		this.strength = (5 * player.getLevel ());
		this.defense = (3 * player.getLevel ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!dead)
		{
			if(!dying)
			{
				if (inSight ())
				{
					// If enemy has player in sight it should approach the player.
					chase ();
				}
				else if(inRange ())
				{
					// if enemy has player in range it should attack the player.
					doAttack ((int)(this.strength * 2.25));
				}
				else if(Vector3.Distance (this.transform.position, terrain.GetComponent<EnemySpawn>().getSpawn(this.id)) > 1)
				{
						returnToPost();
				}
				else
				{
					animation.CrossFade(idle.name);
				}
			}
			else if(!animation.IsPlaying(die.name))
			{
				animation.Play (die.name);
			}
			else if(animation[die.name].time > 1.15)
			{
				dead = true;
				player.setExp (100);
			}
		}
		else if (dead)
		{
			despawnTime ++;
			if(despawnTime > 1500)
			{
				terrain.GetComponent<EnemySpawn>().removeEnemy(this.id);
				foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Enemy"))
				{
					if(gO.GetComponent<Mob>().getId() == this.id)
					{
						gO.SetActive(false);
					}
				}
				despawnTime = 0;
			}
		}
	}

	bool inSight()
	{
		if(player.dying || player.dead)
		{
			return false;
		}
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
		if(player.dying || player.dead)
		{
			return false;
		}
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
		int dealtDamage = damage - defense;
		health -= (dealtDamage > 0) ? dealtDamage : 1;
		Debug.Log ("Target : " + this.health);
		if (health <= 0) 
		{
			dying=true;
			health = 0;
		}
	}

	void returnToPost()
	{
		this.transform.LookAt (terrain.GetComponent<EnemySpawn>().getSpawn(this.id));
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

	void doAttack(int attackStrength)
	{
		if(!animation.IsPlaying (attack.name))
		{
			animation.CrossFade (attack.name);
		}
		if(animation[attack.name].time >= 1.139)
		{
			player.takeDamage (attackStrength);
		}
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

	public bool isDying()
	{
		return dying;
	}

	public bool isDead()
	{
		return dead;
	}
}