using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
	private Vector3 maxpos = new Vector3(70 ,40,0);

	[Header ("Set in Inspector")]
	public Sprite level; // Sets the current level sprite for loading later.
	public GameObject rock;
	public GameObject stick;
	public GameObject zomBunny;
	public int numRocks;
	public int numSticks;

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
		spawnTerrain ();
		spawnEnemies ();
	}

	public void spawnTerrain() {
		for (int i = 0; i < numRocks; i++)
		{
			GameObject temprock = Instantiate<GameObject>(rock);
			temprock.transform.parent = transform;
			temprock.transform.position = new Vector3(Random.Range(-1f,1f) * maxpos.x, Random.Range(-1f, 1f) * maxpos.y, -1);
		}

		for (int i = 0; i < numSticks; i++)
		{
			GameObject tempstick = Instantiate<GameObject>(stick);
			tempstick.transform.parent = transform;
			tempstick.transform.position = new Vector3(Random.Range(-1f, 1f) * maxpos.x, Random.Range(-1f, 1f) * maxpos.y, -1);
		}
	}

	public void spawnEnemies() {
		switch (transform.name) {
		case "Level2(Clone)":
			for (int i = 0; i < Main.M.numLevel2Enemies; i++) {
				GameObject bunny = Instantiate<GameObject> (zomBunny);
				bunny.transform.parent = transform;
				bunny.transform.position = new Vector3 (Random.Range (-1f, 1f) * maxpos.x, Random.Range (-1f, 1f) * maxpos.y, -1);
			}
			break;
		case "Level3(Clone)":
			for (int i = 0; i < Main.M.numLevel3Enemies; i++) {
				GameObject bunny = Instantiate<GameObject> (zomBunny);
				bunny.transform.parent = transform;
				bunny.transform.position = new Vector3 (Random.Range (-1f, 1f) * maxpos.x, Random.Range (-1f, 1f) * maxpos.y, -1);
			}
			break;

		case "Level4(Clone)":
			for (int i = 0; i < Main.M.numLevel4Enemies; i++) {
				GameObject bunny = Instantiate<GameObject> (zomBunny);
				bunny.transform.parent = transform;
				bunny.transform.position = new Vector3 (Random.Range (-1f, 1f) * maxpos.x, Random.Range (-1f, 1f) * maxpos.y, -1);
			}
			break;

		default:
			break;
		}
	}
}
