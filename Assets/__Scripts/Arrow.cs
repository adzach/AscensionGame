using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	float timeFired;
	float timeUntilDisappear;

	// Use this for initialization
	void Start () {
		timeFired = Time.time;
		timeUntilDisappear = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeFired > timeUntilDisappear) {
			Destroy (transform.gameObject);
		}

	}
}
