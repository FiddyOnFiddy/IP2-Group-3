using UnityEngine;
using System.Collections;

public class DoorTriggers : MonoBehaviour 
{
	public GameObject room1Door;
	public GameObject room2Door;

	public Camera room1Camera;
	public Camera room2Camera;
	public Camera hallwayCamera;

	// Use this for initialization
	void Start ()
	{
		room1Door = GameObject.Find ("Room1Door");
		room2Door = GameObject.Find ("Room2Door");

		room1Camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		room2Camera = GameObject.Find("Room2Camera").GetComponent<Camera>();
		hallwayCamera = GameObject.Find("HallwayCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(gameObject.name == "Room1Trigger" && other.gameObject.tag == "Player")
		{
			audio.Play();
			room1Door.SetActive(false);
			room1Camera.enabled = true;
			hallwayCamera.enabled = false;	
		}
		if(gameObject.name == "Room2Trigger" && other.gameObject.tag == "Player")
		{
			audio.Play();
			room2Door.SetActive(false);
			room2Camera.enabled = true;
			hallwayCamera.enabled = false;	
		}
	}
}
