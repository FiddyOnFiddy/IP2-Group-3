using UnityEngine;
using System.Collections;

public class MirrorPiecesScript : MonoBehaviour 
{
	public GameObject barrier1;
	public GameObject barrier2;

	public int mirrorCounter = 0;

	// Use this for initialization
	void Start () 
	{
		barrier1 = GameObject.Find("Barrier1");
		barrier2 = GameObject.Find ("Barrier2");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player" )
		{
			gameObject.SetActive(false);
			barrier1.SetActive(false);
		}

		if(other.gameObject.tag == "Player" && gameObject.name == "Chest2")
		{
			gameObject.SetActive(false);
			barrier2.SetActive(false);
		}
	}
}
