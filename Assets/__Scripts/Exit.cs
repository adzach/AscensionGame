using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
	[Header ("Set in Inspector")]
	public GameObject levelToLeadTo;

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject go = coll.gameObject;
		switch (go.tag) {
		case "Hero":
			// Handle collision with hero (Advance to the next level, however we decide to do that).
			Main.M.changeLevel(levelToLeadTo, this.tag);
			break;
		case "Enemy":
			// Handle collision with enemy. (Act as a border would)
			break;

		default:
			print ("Something collided with a border. It was: " + go.name);
			break;
		}
	}
}
