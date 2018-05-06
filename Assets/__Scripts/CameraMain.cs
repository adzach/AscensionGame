using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour {
	public static GameObject hero;
	private Vector3 offset;
	public static bool gameStarted = false;

	void Start() {
		offset = transform.position; // - hero.transform.position;
	}

	void LateUpdate () {
		if (gameStarted) {
			transform.position = hero.transform.position + offset;
		}
	}
}
