using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour 
{
	public GameObject enemy;
	public Vector3[] spawnPoints;
	private int[] despawnTimes = new int[10];
	private GameObject[] newEnemies = new GameObject[10];

	// Use this for initialization
	void Start () 
	{
		enemy.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i=0; i < spawnPoints.Length; i++)
		{
			if(newEnemies[i] == null)
			{
				newEnemies[i] = (GameObject) GameObject.Instantiate (enemy, spawnPoints[i], transform.rotation);
				newEnemies[i].SetActive(true);
				newEnemies[i].GetComponent <Mob>().setId(i);
			}
			if(newEnemies[i].GetComponent<Mob>().isDead())
			{
				despawnTimes[i]++;
				if(despawnTimes[i] > 1500)
				{
					removeEnemy(i);
					despawnTimes[i] = 0;
				}
			}
		}
	}

	public Vector3 getSpawn(int index)
	{
		return spawnPoints[index];
	}

	public void removeEnemy(int id)
	{
		GameObject.Destroy(newEnemies [id]);
		newEnemies [id] = null;
	}
}