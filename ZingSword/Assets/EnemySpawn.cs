using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour 
{
	public GameObject enemy;
	public Vector3[] spawnPoints;
	public bool[] spawned;
	private List<GameObject> newEnemies = new List<GameObject>();

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
			if(!spawned[i])
			{
				newEnemies.Insert(i, (GameObject) GameObject.Instantiate (enemy, spawnPoints[i], transform.rotation));
				spawned[i] = true;
				Debug.Log (newEnemies[i].transform.position.ToString () + " " + enemy.ToString ());
				newEnemies[i].SetActive(true);
				newEnemies[i].GetComponent <Mob>().setId(i);
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
		spawned [id] = false;
	}
}