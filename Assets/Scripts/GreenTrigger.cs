using UnityEngine;
using System.Collections;

public class GreenTrigger : MonoBehaviour 
{
	public Sprite greenTriggerNotActive;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//Checks if the correct crate has landed in the trigger
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "CrateGreen")
		{
			audio.Play();
			other.gameObject.SetActive(false);
			OpenDoor openDoor = GameObject.Find("doorTrigger").GetComponent<OpenDoor>();
			openDoor.triggerCount ++;
			Debug.Log (openDoor.triggerCount);
			SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>();
			spriterenderer.sprite = greenTriggerNotActive;
		}
	}
}
