using UnityEngine;
using System.Collections;

public class MoveObstacleScript : MonoBehaviour 
{

	private float radiusPush = 1.0f;
	private float radiusPull = 1.1f;
	public float pullHorizontal = 0.7f;
	public float pullVertical = 0.7f;
	public GameObject player;
	public GameObject left;
	public GameObject right;
	public GameObject up;
	public GameObject down;
	public bool canMove = false;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveObstacle();
	}

	void MoveObstacle()
	{
		float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
		Debug.DrawLine(player.transform.position, gameObject.transform.position);

		//For pushing a box
		if(dist < radiusPush && Input.GetKey("f"))
		{
			if(Input.GetAxis("Horizontal") > 0)
			{
				//iTween.MoveTo (this.gameObject, new Vector3(right.transform.position.x, right.transform.position.y, 0), 0.3f);
				iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(1,0,0),"time",0.3,"oncomplete","OnComplete"));
				audio.Play();
			}
			else if (Input.GetAxis ("Horizontal") < 0)
			{
				//iTween.MoveTo (this.gameObject, new Vector3(left.transform.position.x, left.transform.position.y, 0), 0.3f);
				iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(-1,0,0),"time",0.3,"oncomplete","OnComplete"));
				audio.Play();
			}
			else if (Input.GetAxis("Vertical") > 0 )
			{
				//iTween.MoveTo (this.gameObject, new Vector3(up.transform.position.x, up.transform.position.y, 0), 0.3f);
				iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(0,1,0),"time",0.3,"oncomplete","OnComplete"));
				audio.Play();
			}
			else if (Input.GetAxis("Vertical") < 0 )
			{
				//iTween.MoveTo (this.gameObject, new Vector3(down.transform.position.x, down.transform.position.y, 0), 0.3f);
				iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(0,-1,0),"time",0.3,"oncomplete","OnComplete"));
				audio.Play();
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
		if(dist < radiusPull && Input.GetKey("e"))
		{

			if(hitRight != null && hitRight.collider != null)
			{

				if(Input.GetAxis ("Horizontal") > 0 && hitRight.collider.tag == "Player" )
				{
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(1f,0,0),"time",pullHorizontal,"oncomplete","OnComplete"));
					audio.Play();
				}
			}

			if(hitLeft != null && hitLeft.collider != null)
			{
				if (Input.GetAxis ("Horizontal") < 0 && hitLeft.collider.tag == "Player")
				{
					//iTween.MoveBy(this.gameObject, new Vector3(-1, 0, 0), 0.7f);
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(-1f,0,0),"time",pullHorizontal,"oncomplete","OnComplete"));
					audio.Play();

				}
			}
			if(hitUp != null && hitUp.collider != null)
			{
				if (Input.GetAxis("Vertical") > 0 && hitUp.collider.tag == "Player")
				{
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(0,1f,0),"time",pullVertical,"oncomplete","OnComplete"));
					audio.Play();
				}
			}
			if(hitDown != null && hitDown.collider != null )
			{
				if (Input.GetAxis("Vertical") < 0 && hitDown.collider.tag == "Player")
				{
					//iTween.MoveBy(this.gameObject, new Vector3(1, -1, 0), 0.7f);
					iTween.MoveBy(this.gameObject,iTween.Hash("amount",new Vector3(0,-1f,0),"time",pullVertical,"oncomplete","OnComplete"));
					audio.Play();

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
