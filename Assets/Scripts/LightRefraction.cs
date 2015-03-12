using UnityEngine;
using System.Collections;

//This is light refraction script
public class LightRefraction : MonoBehaviour 
{
	private LineRenderer lineRenderer;
	public Vector3 direction;
	public bool enable=false;
	public float distance=50.0f;

	// Use this for initialization
	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer>();
		direction = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Laser();
	}

	public void Laser()
	{
		if (enable) {
			lineRenderer.enabled=true;

			RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, Vector3.up*distance);

			if (hit!=null)
			{
				if (hit.collider.tag=="Goal")
				{
					Debug.Log ("Puzzle Solved");
				}
				else
				{
					Vector3 reflectDir=Vector3.Reflect(direction,hit.normal);
					LightRefraction laser=hit.collider.gameObject.GetComponent<LightRefraction>();
					laser.enable=true;
					laser.direction=reflectDir;
				}
			}
		}


		/*
		Debug.DrawRay(transform.position, -transform.up * 50, Color.black);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity);

		lineRenderer.enabled = true;
		lineRenderer.SetVertexCount(2);
		lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, hit.point);


		if( hit != null && hit.collider != null)
		{
			Vector3 inDirection = Vector3.Reflect(-transform.up, hit.normal);

			Debug.DrawRay(hit.point, inDirection * 100, Color.red);
			hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, Mathf.Infinity);

			lineRenderer.SetPosition(0, inDirection);
			slineRenderer.SetPosition(1, hit.point);


			if (hit != null && hit.collider != null)
			{
				inDirection = Vector3.Reflect(inDirection, hit.normal);
				Debug.DrawRay(hit.point, inDirection * 100, Color.green);

				hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, Mathf.Infinity);


				if(hit != null && hit.collider != null)
				{
					inDirection = Vector3.Reflect(inDirection, hit.normal);
					Debug.DrawRay(hit.point, inDirection * 100, Color.blue);
				}
			}

		}*/
	}
	
}
