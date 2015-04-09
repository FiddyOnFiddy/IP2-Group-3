using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour 
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
		if(other.gameObject.tag == "Player" && gameObject.name == "endSceneTrigger")
		{
			Application.LoadLevel("Level01");
		}
		if(other.gameObject.tag == "Player" && gameObject.name == "_endGameTrigger")
		{
			Application.LoadLevel("EndMenu");
		}
	}
}
