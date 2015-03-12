using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AIPathScript : MonoBehaviour 
{
	public List<Transform> path;
	public Color rayColor = Color.black;




	void OnDrawGizmos()
	{
		Gizmos.color = rayColor;



		List<Transform> pathObjs = new List<Transform>();
		pathObjs.AddRange(transform.GetComponentsInChildren<Transform>());
		path = new List<Transform>();

		foreach(Transform pathObj in pathObjs)
		{
			if(pathObj != transform)
			{
				path.Add (pathObj);
			}
		}

		for (int i = 0; i < path.Count; i++) 
		{
			Vector3 pos = path[i].position;

			if(i > 0)
			{
				Vector3 previous = path[i-1].position;
				Gizmos.DrawLine (previous, pos);
				Gizmos.DrawWireSphere(pos, 0.3f);
			}
		}

	}
}
