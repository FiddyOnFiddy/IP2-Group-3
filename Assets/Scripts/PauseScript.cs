using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour 
{
	public Canvas canvas;

	void Start()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled =false;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
	}

	//Toggles the canvas on and off and pauses the game.
	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	//Restarts the current level.
	public void Restart()
	{
		Pause();
		Application.LoadLevel(Application.loadedLevel);
	}

	//Quits the game, if in editor it stops the game and if in an application it quits the application.
	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
