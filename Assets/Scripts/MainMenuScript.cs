using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	public AudioClip backgroundMusic;

	// Use this for initialization
	void Start ()
	{
		GameObject musicObject = GameObject.Find("MusicObject");
		if (musicObject == null)
		{
			musicObject = new GameObject();
			musicObject.name = "MusicObject";
			musicObject.AddComponent("BackgroundMusicScript");
			AudioSource audioSource = musicObject.AddComponent<AudioSource>();
			audioSource.clip = backgroundMusic;
			audioSource.playOnAwake = false;
			audioSource.Play();
			audioSource.loop = true;
		}
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
		Application.LoadLevel ("OptionsScene");
		audio.Play();
	}

	public void QuitButton()
	{
		audio.Play();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void Replay()
	{
		audio.Play ();
		Application.LoadLevel("TutorialLevel");
	}

	public void BackButton()
	{
		audio.Play();
		Application.LoadLevel("MainMenu");
	}
}
