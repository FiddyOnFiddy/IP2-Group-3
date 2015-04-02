using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	public int triggerCount = 0;

	public GameObject door1;

	public GameObject door2;
	public GameObject door3;

	public GameObject barrier;
	public GameObject barrier2;

	public Camera cameraMain;
	public Camera camera2;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(triggerCount == 3)
		{
			iTween.MoveBy(door1.gameObject, new Vector3(-1, 0, 0), 1.0f);
			door1.SetActive(false);
			audio.Play();
		}

		if(triggerCount == 6)
		{
			iTween.MoveBy(barrier.gameObject, new Vector3(-1, 0, 0), 1.0f);
			barrier.SetActive(false);
			iTween.MoveBy(barrier2.gameObject, new Vector3(1, 0, 0), 1.0f);
			barrier2.SetActive(false);
			audio.Play();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			iTween.MoveBy(door2.gameObject, new Vector3(-1, 0, 0), 1.0f);
			door2.SetActive(false);
			iTween.MoveBy(door3.gameObject, new Vector3(1, 0, 0), 1.0f);
			door3.SetActive(false);
			cameraMain.enabled = false;
			camera2.enabled = true;
			audio.Play();
		}
	}
}
