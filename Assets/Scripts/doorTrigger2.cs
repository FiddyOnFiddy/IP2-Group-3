using UnityEngine;
using System.Collections;

public class doorTrigger2 : MonoBehaviour 
{
	public GameObject door2;
	public GameObject door3;
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
		OpenDoor openDoor = GameObject.Find("doorTrigger").GetComponent<OpenDoor>();

		if(other.gameObject.tag == "Player" && openDoor.triggerCount >= 6)
		{
			iTween.MoveBy(door2.gameObject, new Vector3(-1, 0, 0), 1.0f);
			door2.SetActive(false);
			iTween.MoveBy(door3.gameObject, new Vector3(1, 0, 0), 1.0f);
			door3.SetActive(false);
			audio.Play();
		}
	}
}
