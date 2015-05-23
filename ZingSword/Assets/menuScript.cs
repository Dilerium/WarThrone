using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Button exitGame;
	public Button startGame;
	public Button settingsGame;
	public Button creditsGame;
	// Use this for initialization
	void Start () {
		startGame = startGame.GetComponent<Button>();
		exitGame = exitGame.GetComponent<Button>();
		settingsGame = settingsGame.GetComponent<Button>();
		creditsGame = creditsGame.GetComponent<Button>();
	}

	public void ExitPress()
	{
		startGame.enabled = false;
		exitGame.enabled = false;
		settingsGame.enabled = false;
		creditsGame.enabled = false;
	}
	public void NoPress()
	{
		startGame.enabled = true;
		exitGame.enabled = true;
		settingsGame.enabled = true;
		creditsGame.enabled = true;
	}
	public void StartLevel()
	{
		Application.LoadLevel (1);
	}
	public void StartSettings()
	{
		Application.LoadLevel (2);
	}
	public void StartCredits()
	{
		Application.LoadLevel (3);
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
