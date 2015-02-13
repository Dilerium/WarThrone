using UnityEngine;
using System.Collections;

public class ClickToMoveCharControll : MonoBehaviour {
	public float speed;
	public CharacterController controller;
	private Vector3 position;

	public AnimationClip run;
	public AnimationClip idle;
	public static bool attack;


	// Use this for initialization
	void Start () 
	{
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!attack) 
		{
			if (Input.GetMouseButton (0)) 
			{
				//Local where the player clicked on terrain
				locatePosition ();
			}
			moveToPosition ();
		} 
		else 
		{

		}
		//move the player to the position
	
	}
	void locatePosition()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(ray, out hit, 1000))
		{
			if(hit.collider.tag != "Player")
			{
				position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			}
		}
	}

	void moveToPosition()
	{


		//game object move
		if (Vector3.Distance (transform.position, position) > 1) 
		{

			Quaternion newRotation = Quaternion.LookRotation (position - transform.position, Vector3.forward);

			newRotation.x = 0f;
			newRotation.z = 0f;
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
			controller.SimpleMove (transform.forward * speed);

			animation.CrossFade(run.name);
		} 
		//game objet is not moving
		else 
		{
			animation.CrossFade(idle.name);
		}

	}


}
