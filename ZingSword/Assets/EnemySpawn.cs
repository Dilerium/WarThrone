using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour 
{
	public GameObject enemy;
	public Vector3[] spawnPoints;
	public bool[] spawned;
	private List<Mob> newEnemies = new List<Mob>();
	private static Vector3[] spawnPoints2;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i=0; i < spawnPoints.Length; i++)
		{
			if(!spawned[i])
			{
				newEnemies.Add((Mob) GameObject.Instantiate (enemy.GetComponent ("Mob"), spawnPoints[i], transform.rotation));
				spawned[i] = true;
				Debug.Log (newEnemies[i].transform.position.ToString () + " " + enemy.ToString ());
				newEnemies[i].setId(i);
			}
			/*if(newEnemies[i] == null)
			{
				spawned[i] = false;
			}*/
		}
		spawnPoints2 = spawnPoints;
	}

	public Vector3 getSpawn(int index)
	{
		return spawnPoints2[index];
	}

	public void removeEnemy(int id)
	{
		newEnemies [id] = null;
	}
}