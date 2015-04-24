using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	// Use this for initialization
    // creatting an index, so every child has and his own index
	void Start () 
    {
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).GetComponent<CharacterSlot>().index = i;
        }
	}
	
}
