using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	public int triggerCount = 0;

	public GameObject wall;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject wall4;
	public GameObject wall5;

	public GameObject wall6;
	public GameObject wall7;
	public GameObject wall8;
	public GameObject wall9;

	public GameObject wall10;
	public GameObject wall11;
	public GameObject wall12;
	public GameObject wall13;

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
			wall5.SetActive(false);
		}

		if(triggerCount == 6)
		{
			wall6.SetActive(false);
			wall7.SetActive(false);
			wall8.SetActive(false);
			wall9.SetActive(false);
		}

		if(triggerCount == 9)
		{
			wall10.SetActive(false);
			wall11.SetActive(false);
			wall12.SetActive(false);
			wall13.SetActive(false);
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
