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

	void OnTriggerEnter(Collider other)
	{
		if(other.collider.tag == "Player")
		{
			Application.LoadLevel("EndMenu");
		}
	}
}
