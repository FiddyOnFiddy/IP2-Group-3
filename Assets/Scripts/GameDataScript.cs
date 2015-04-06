using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour 
{
	public int mirrorPieces;
	// Use this for initialization
	void Start ()
	{
		if(gameObject != null)
		{
			DontDestroyOnLoad(this);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
