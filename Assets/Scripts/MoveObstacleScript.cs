using UnityEngine;
using System.Collections;

public class MoveObstacleScript : MonoBehaviour 
{

	private float radiusPush = 0.5f;
	private float radiusPull = 0.6f;
	public GameObject player;
	public GameObject left;
	public GameObject right;
	public GameObject up;
	public GameObject down;

	public Vector3 prevPos;
	public bool isMoving;


	// Use this for initialization
	void Start () 
	{
		prevPos = gameObject.transform.position;
		isMoving = false;
		//InvokeRepeating("CheckForMove", 0.001f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveObstacle();
	}

	/*void CheckForMove()
	{
		if(prevPos != gameObject.transform.position)
		{
			isMoving = true;
			prevPos = gameObject.transform.position;
		}
		else
		{
			isMoving = false;
		}
	}*/

	void MoveObstacle()
	{
		float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
		Debug.DrawLine(player.transform.position, gameObject.transform.position);

		//For pushing a box
		if(dist < radiusPush && Input.GetKey("f"))
		{
			if(Input.GetAxis("Horizontal") > 0)
			{
				//iTween.MoveTo (this.gameObject, gameObject.transform.TransformDirection(new Vector3(right.transform.position.x, right.transform.position.y, 0)), 0.5f);
				iTween.MoveTo (this.gameObject, new Vector3(right.transform.position.x, right.transform.position.y, 0), 0.3f);
			}
			else if (Input.GetAxis ("Horizontal") < 0)
			{
				iTween.MoveTo (this.gameObject, new Vector3(left.transform.position.x, left.transform.position.y, 0), 0.3f);
			}
			else if (Input.GetAxis("Vertical") > 0 )
			{
				iTween.MoveTo (this.gameObject, new Vector3(up.transform.position.x, up.transform.position.y, 0), 0.3f);
			}
			else if (Input.GetAxis("Vertical") < 0 )
			{
				iTween.MoveTo (this.gameObject, new Vector3(down.transform.position.x, down.transform.position.y, 0), 0.3f);
			}
		}

		RaycastHit2D hitRight = Physics2D.Raycast(right.transform.position, Vector2.right, 1.0f);
		Debug.DrawRay(right.transform.position, Vector3.right * 5, Color.black);

		RaycastHit2D hitLeft = Physics2D.Raycast(left.transform.position, -Vector2.right, 1.0f);
		Debug.DrawRay(left.transform.position, -Vector3.right * 5, Color.black);

		RaycastHit2D hitUp = Physics2D.Raycast(up.transform.position, Vector2.up, 1.0f);
		Debug.DrawRay(up.transform.position, Vector3.up * 5, Color.black);

		RaycastHit2D hitDown = Physics2D.Raycast(down.transform.position, -Vector2.up, 1.0f);
		Debug.DrawRay(down.transform.position, Vector3.down * 5, Color.black);
		
		//For pulling a box
		if(dist < radiusPull && Input.GetKey("e") /*&& !isMoving*/)
		{

			if(hitRight != null && hitRight.collider != null)
			{
				if(Input.GetAxis ("Horizontal") > 0 && hitRight.collider.tag == "Player" )
				{
					//iTween.MoveTo (this.gameObject, new Vector3(player.transform.position.x, player.transform.position.y, 0), 0.3f);
					//iTween.MoveBy(this.gameObject, new Vector3(1, 0, 0), 0.7f);

					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(1,0,0),"time",0.7,"oncomplete","OnComplete"));
				}
			}

			if(hitLeft != null && hitLeft.collider != null)
			{
				if (Input.GetAxis ("Horizontal") < 0 && hitLeft.collider.tag == "Player")
				{
					//iTween.MoveBy(this.gameObject, new Vector3(-1, 0, 0), 0.7f);
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(-1,0,0),"time",0.7,"oncomplete","OnComplete"));

				}
			}
			if(hitUp != null && hitUp.collider != null)
			{
				if (Input.GetAxis("Vertical") > 0 && hitUp.collider.tag == "Player")
				{
					//iTween.MoveBy(this.gameObject, new Vector3(0, 1, 0), 0.7f);
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(0,1,0),"time",0.7,"oncomplete","OnComplete"));

				}
			}
			if(hitDown != null && hitDown.collider != null)
			{
				if (Input.GetAxis("Vertical") < 0 && hitDown.collider.tag == "Player")
				{
					//iTween.MoveBy(this.gameObject, new Vector3(1, -1, 0), 0.7f);
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(0,-1,0),"time",0.7,"oncomplete","OnComplete"));

				}
			}

		}
	}

	void OnComplete()
	{
		Vector3 position = gameObject.transform.position;
		gameObject.transform.position = new Vector3 (Mathf.Round (position.x), Mathf.Round (position.y), Mathf.Round (position.z));
	}
	
}
