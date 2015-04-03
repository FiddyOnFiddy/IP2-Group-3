using UnityEngine;
using System.Collections;

public class BlueTriggr : MonoBehaviour 
{
	public Sprite blueTriggerNotActive;

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
		if(other.gameObject.name == "CrateBlue")
		{
			audio.Play();
			other.gameObject.SetActive(false);
			OpenDoor openDoor = GameObject.Find("doorTrigger").GetComponent<OpenDoor>();
			openDoor.triggerCount ++;
			Debug.Log (openDoor.triggerCount);
			SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>();
			spriterenderer.sprite = blueTriggerNotActive;
		}
	}
}
