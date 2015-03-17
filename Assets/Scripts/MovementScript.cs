using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	float rotationSpeed=3.0f;
	public LightRefraction light;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		light.direction = transform.up;
		transform.Rotate (Vector3.forward, Input.GetAxis ("Horizontal") * rotationSpeed*-1);
	}
}
