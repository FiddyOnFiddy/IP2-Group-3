using UnityEngine;
using System.Collections;

public class RedTrigger : MonoBehaviour 
{

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
		if(other.gameObject.name == "redCrate")
		{
			other.gameObject.SetActive(false);
			OpenDoor openDoor = GameObject.Find("endSceneTrigger").GetComponent<OpenDoor>();
			openDoor.triggerCount++;
			Debug.Log (openDoor.triggerCount);
		}
	}
}
