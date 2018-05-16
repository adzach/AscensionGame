using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour {

	[Header ("Set in Inspector")]
	public GameObject level;
	public float velocity;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (11110, 11110, -1);
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = startPosition + new Vector3 (Mathf.Sin (Time.time) * velocity, 0.0f, 0.0f);
	}
}
