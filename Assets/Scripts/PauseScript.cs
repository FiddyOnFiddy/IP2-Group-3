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

	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void Restart()
	{
		Pause();
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
