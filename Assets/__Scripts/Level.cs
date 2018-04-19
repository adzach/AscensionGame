using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
	[Header ("Set in Inspector")]
	public Sprite level; // Sets the current level sprite for loading later.
//	public Hero hero;
//	public Enemy[] enemies;

	[Header ("Set Dynamically")]
	public List<Border> borders;
	public List<Exit> exits;

	// Use this for initialization
	void Start () {
		borders = new List<Border> ();
		exits = new List<Exit> ();
		
		foreach (Transform t in this.GetComponentsInChildren<Transform>()) {
			if (t.tag == "BorderObject") { // Adds collidable borders to list
				borders.Add (t.GetComponent<Border> ());
			} else {
				if (t.tag != "Untagged") { // What's remaining is an exit, so add it
					exits.Add(t.GetComponent<Exit> ());
				}
			}
		}

//		foreach (Border b in borders) {
//			print ("This is a border: " + b.name);
//		}
//
//		foreach (Exit e in exits) {
//			print ("This is an exit: " + e.name);
//		}
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
