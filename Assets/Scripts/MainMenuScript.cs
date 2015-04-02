using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void PlayButton()
	{
		audio.Play();
		Application.LoadLevel("TutorialLevel");
	}

	public void OptionsMenu()
	{
		audio.Play();
	}

	public void QuitButton()
	{
		audio.Play();
		Application.Quit();
	}
}
