using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour {

	[Header ("Set in Inspector")]
	public GameObject level;
	public float velocity;

	private float widthLevel;
	private float widthFog;
	private float leftEdgeLevel;
	private float rightEdgeLevel;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 0, -1);
		widthLevel = level.GetComponent<Renderer> ().bounds.size.x;
		widthFog = transform.gameObject.GetComponent<Renderer> ().bounds.size.x;
		leftEdgeLevel = level.transform.position.x - (widthLevel / 2);
		rightEdgeLevel = level.transform.position.x + (widthLevel / 2);
	}
	
	// Update is called once per frame
	void Update () {
		float leftEdgeFog = transform.position.x - (widthFog / 2);
		float rightEdgeFog = transform.position.x + (widthFog / 2);

		if (leftEdgeFog >= leftEdgeLevel) {
			transform.position = new Vector3 (rightEdgeLevel - (widthLevel / 2), transform.position.y, transform.position.z);
		}
		transform.position = new Vector3 (transform.position.x + velocity, transform.position.y, transform.position.z);
	}
}
