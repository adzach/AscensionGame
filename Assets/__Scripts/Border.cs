using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject go = coll.gameObject;
		switch (go.tag) {
		case "Hero":
			// Handle collision with hero
			break;
		case "Enemy":
			// Handle collision with enemy
			break;

		default:
			break;
		}
	}

}
