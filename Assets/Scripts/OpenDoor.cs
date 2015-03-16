using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	public int triggerCount = 0;

	public GameObject wall;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject wall4;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(triggerCount == 3)
		{
			wall.SetActive(false);
			wall2.SetActive(false);
			wall3.SetActive(false);
			wall4.SetActive(false);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Application.LoadLevel ("Level01");
		}
	}
}
