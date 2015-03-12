using UnityEngine;
using System.Collections;

//This is light refraction script
public class LightRefraction : MonoBehaviour 
{
	private LineRenderer lineRenderer;
	public Vector3 direction;
	public bool enable = false;
	public float distance = 50.0f;



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

		if (enable) 
		{
			lineRenderer.enabled=true;

			var endPoint = transform.position + direction * 10000.0f;


			RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
			Debug.DrawRay(transform.position, direction * 50, Color.black);
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, transform.position);

			if (hit!=null && hit.collider != null )
			{
				if (hit.collider.tag == "Goal")
				{
					Debug.Log ("Puzzle Solved");
				}
				else
				{
					endPoint = hit.point;
					Vector3 reflectDir = Vector3.Reflect(-transform.up,hit.normal);
					LightRefraction laser = hit.collider.gameObject.GetComponent<LightRefraction>();
					laser.enable = true;
					laser.direction = Vector3.Reflect(reflectDir, hit.normal);
				}
			}

			lineRenderer.SetPosition(1, endPoint);


		}



		/*Debug.DrawRay(transform.position, -transform.up * 50, Color.black);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity);

		lineRenderer.enabled = true;
		lineRenderer.SetVertexCount(2);
		lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, transform.position);
		lineRenderer.SetWidth(0.5f, 0.5f);


		if( hit != null && hit.collider != null)
		{
			Vector3 inDirection = Vector3.Reflect(-transform.up, hit.normal);

			Debug.DrawRay(hit.point, inDirection * 100, Color.red);
			hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, Mathf.Infinity);

			crateLineRenderer.enabled = true;
			crateLineRenderer.SetVertexCount(2);
			crateLineRenderer.SetPosition(0, hit.normal);
			crateLineRenderer.SetPosition(1, hit.point);


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
