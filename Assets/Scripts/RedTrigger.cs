using UnityEngine;
using System.Collections;

public class RedTrigger : MonoBehaviour 
{
	public Sprite redTriggerNotActive;

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
		if(other.gameObject.name == "CrateRed")
		{
			audio.Play ();
			other.gameObject.SetActive(false);
			OpenDoor openDoor = GameObject.Find("doorTrigger").GetComponent<OpenDoor>();
			openDoor.triggerCount++;
			Debug.Log (openDoor.triggerCount);
			SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>();
			spriterenderer.sprite = redTriggerNotActive;
		}
	}
}
