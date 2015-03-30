using System.Collections;
using UnityEngine;

class TileMovement : MonoBehaviour 
{
	public float moveSpeed = 3f;
	public float gridSize = 1.0f;
	private enum Orientation 
	{
		Horizontal,
		Vertical
	};
	private Orientation gridOrientation = Orientation.Vertical;
	private bool allowDiagonals = false;
	private bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;

	private float radius = 0.5f;

	public Sprite playerLeft;
	public Sprite playerRight;
	public Sprite playerForward;
	public Sprite playerBackwards;

	public GameObject left;
	public GameObject right;
	public GameObject up;
	public GameObject down;
	

	public void Update() 
	{

		WalkingAnimation ();



		if (!isMoving) 
		{
			input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if (!allowDiagonals) 
			{
				if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) 
				{
					input.y = 0;
				} else 
				{
					input.x = 0;
				}
			}
			
			if (input != Vector2.zero) 
			{
				StartCoroutine(move(transform));
			}
		}
	}


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll != null)
		{
			gameObject.transform.rotation = Quaternion.identity;
			endPosition = startPosition;
			Debug.Log("collided");
		}
		
	}


		void WalkingAnimation()
		{
				if (Input.GetAxis ("Horizontal") < 0) 
				{
						SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
						spriteRenderer.sprite = playerLeft;
				}
				if (Input.GetAxis ("Horizontal") > 0) 
				{
						SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
						spriteRenderer.sprite = playerRight;
				}
				if (Input.GetAxis ("Vertical") > 0) 
				{
						SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
						spriteRenderer.sprite = playerForward;
				}
				if (Input.GetAxis ("Vertical") < 0) 
				{
						SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
						spriteRenderer.sprite = playerBackwards;
				}

		}
	
	public IEnumerator move(Transform transform) 
	{
		isMoving = true;
		startPosition = transform.position;
		t = 0;
		
		if(gridOrientation == Orientation.Horizontal) 
		{
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		} 
		else
		{
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          (startPosition.y + System.Math.Sign(input.y) * gridSize), startPosition.z);
		}
		
		if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) 
		{
			factor = 0.7071f;
		} 
		else 
		{
			factor = 1f;
		}
		
		while (t < 1f)
		{
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
		
		isMoving = false;
		yield return 0;
	}
}
