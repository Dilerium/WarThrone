using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).GetComponent<CharacterSlot>().index = i;
        }
	}
	
}
