using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour {
	[Header ("Set in Inspector")]
	public GameObject hero;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - hero.transform.position;
	}

	void LateUpdate () {
		transform.position = hero.transform.position + offset;
	}
}
