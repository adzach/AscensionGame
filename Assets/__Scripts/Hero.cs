using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	static public Hero S;

	[Header ("Set in Inspector")]
	public float speed = 30;

	void Awake () {
		if (S == null) {
			S = this;
		} else {
			Debug.LogError ("Attempted to assign second hero");
		}
	}

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (-5, -5, -1);
	}
	
	// Update is called once per frame
	void Update () {
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;
	}
}
