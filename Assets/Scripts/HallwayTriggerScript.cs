using UnityEngine;
using System.Collections;

public class HallwayTriggerScript : MonoBehaviour 
{
	public Camera room1Camera;
	public Camera room2Camera;
	public Camera hallwayCamera;


	// Use this for initialization
	void Start () 
	{
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
		if(other.gameObject.tag == "Player")
		{
			room1Camera.enabled = false;
			room2Camera.enabled = false;
			hallwayCamera.enabled = true;	
		}
	}
}
