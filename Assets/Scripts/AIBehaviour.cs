using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AIBehaviour : MonoBehaviour 
{
	public List<Transform> path;
	public Transform pathGroup;
	public int currentPathObj;
	public GameObject player;

	public enum PathReset
	{
		loop = 0,
		reverse = 1,
		random = 2
	}

	public PathReset pathReset;

	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;

	public float moveSpeed = 0.1f;
	private float radius = 1f;

	public GameObject checkpoint;
	public AudioClip damaged;
	public AudioClip growl;


	// Use this for initialization
	void Start () 
	{
		GetPath();
		checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
		CollisionDetection();
	}

	void CollisionDetection()
	{
		float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
		Debug.DrawLine(gameObject.transform.position, player.transform.position);


		if(distance < 0.5f)
		{
			Debug.Log ("Player has collided");
			player.transform.position = GameObject.FindGameObjectWithTag("Checkpoint").transform.position;
			audio.clip = damaged;
			audio.Play();
		}

		if(distance < 3.5f)
		{
			audio.clip = growl;
			audio.Play();
			audio.volume = 0.7f;
		}

	}

	void Move()
	{
		float dis = Vector3.Distance(gameObject.transform.position, path[currentPathObj].position);

		if(dis < radius)
		{
			currentPathObj++;
		}

		if(currentPathObj >= path.Count)
		{
			if(pathReset == PathReset.loop)
			{
				currentPathObj = 0;
			}
			else if(pathReset == PathReset.reverse)
			{
				currentPathObj = 0;
				path.Reverse();
			}
		}

		iTween.MoveTo (gameObject, new Vector3(path[currentPathObj].position.x, path[currentPathObj].position.y , gameObject.transform.position.z), moveSpeed);
	}

	void GetPath()
	{
		List<Transform> pathObjs = new List<Transform>();
		pathObjs.AddRange(pathGroup.GetComponentsInChildren<Transform>());
		path = new List<Transform>();
		
		foreach(Transform pathObj in pathObjs)
		{
			if(pathObj != pathGroup)
			{
				path.Add (pathObj);
			}
		}
	}

	static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}
}
