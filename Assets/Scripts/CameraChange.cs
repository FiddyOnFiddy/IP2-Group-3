using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour 
{
	public Camera camera3;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			OpenDoor openDoor = GameObject.Find("doorTrigger").GetComponent<OpenDoor>();
			openDoor.cameraMain.enabled = true;
			openDoor.camera2.enabled = false;
			camera3.enabled = false;
		}
	}
}
