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

	public GameObject mirror1;
	public GameObject mirror2;

	// Use this for initialization
	void Start () 
	{
		mirror1.SetActive(false);
		mirror2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(triggerCount == 3)
		{
			door1.SetActive(false);
			audio.Play();
		}

		if(triggerCount == 6)
		{
			barrier.SetActive(false);
			barrier2.SetActive(false);
			audio.Play();
			mirror1.SetActive(true);
		}

		if(triggerCount == 9)
		{
			mirror2.SetActive(true);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			door2.SetActive(false);
			door3.SetActive(false);
			cameraMain.enabled = false;
			camera2.enabled = true;
			audio.Play();
		}
	}
}
