using UnityEngine;
using System.Collections;

public class CameraChangeFinale : MonoBehaviour
{
	public Camera mainCamera;

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
			openDoor.cameraMain.enabled = false;
			mainCamera.enabled = true;
		}
	}
}
