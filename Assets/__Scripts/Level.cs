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
	public int enemyCount;
	public GameObject bramble;

	// Use this for initialization
	void Start () {
		
		foreach (Transform t in this.GetComponentsInChildren<Transform>()) {
			if (t.tag == "Bramble") {
				bramble = t.gameObject;
				break;
			}
		}
		spawnTerrain ();
		spawnEnemies ();
	}

	void Update() {
		switch (transform.name) {
		case "Level2(Clone)":
			enemyCount = Main.M.numLevel2Enemies;
			break;
		case "Level3(Clone)":
			enemyCount = Main.M.numLevel3Enemies;
			break;
		case "Level4(Clone)":
			enemyCount = Main.M.numLevel4Enemies;
			break;
		case "Level6(Clone)":
			enemyCount = Main.M.numLevel6Enemies;
			break;
		default:
			break;
		}

		if (enemyCount != null) {
			if (enemyCount == 0) {
				Destroy (bramble);
			}
		}
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
			enemyCount = Main.M.numLevel2Enemies;
			break;
		case "Level3(Clone)":
			for (int i = 0; i < Main.M.numLevel3Enemies; i++) {
				GameObject bunny = Instantiate<GameObject> (zomBunny);
				bunny.transform.parent = transform;
				bunny.transform.position = new Vector3 (Random.Range (-1f, 1f) * maxpos.x, Random.Range (-1f, 1f) * maxpos.y, -1);
			}
			enemyCount = Main.M.numLevel3Enemies;
			break;

		case "Level4(Clone)":
			for (int i = 0; i < Main.M.numLevel4Enemies; i++) {
				GameObject bunny = Instantiate<GameObject> (zomBunny);
				bunny.transform.parent = transform;
				bunny.transform.position = new Vector3 (Random.Range (-1f, 1f) * maxpos.x, Random.Range (-1f, 1f) * maxpos.y, -1);
			}
			enemyCount = Main.M.numLevel4Enemies;
			break;

		case "Level6(Clone)":
			for (int i = 0; i < Main.M.numLevel6Enemies; i++) {
				GameObject bunny = Instantiate<GameObject> (zomBunny);
				bunny.transform.parent = transform;
				bunny.transform.position = new Vector3 (Random.Range (-1f, 1f) * maxpos.x, Random.Range (-1f, 1f) * maxpos.y, -1);
			}
			enemyCount = Main.M.numLevel6Enemies;
			break;

		default:
			break;
		}
	}
}
