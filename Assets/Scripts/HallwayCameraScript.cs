using UnityEngine;
using System.Collections;

public class HallwayCameraScript : MonoBehaviour 
{

	// Use this for initialization
	public float dampTime = 0f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target && camera.enabled == true)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
