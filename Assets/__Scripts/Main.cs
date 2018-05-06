using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	static public Main M;

	[Header ("Set in Inspector")]
	public GameObject[] levels;
	public Vector3 levelPos;
	public GameObject hero;

	[Header ("Set Dynamically")]
	public GameObject level;

	void Awake () {
		if (M == null) {
			M = this;
		}
	}

	// Use this for initialization
	void Start () {
		level = Instantiate<GameObject> (levels [0]);
		level.transform.position = levelPos;
        hero = Instantiate<GameObject>(hero);
        hero.transform.position = new Vector3(0,0,0);
	}

	public void changeLevel(GameObject levelToLeadTo, string directionComingFrom) {
		if (levelToLeadTo != null) {
			Destroy (level);
			level = Instantiate<GameObject> (levelToLeadTo);
			level.transform.position = levelPos;

			switch (directionComingFrom) {
			case "TopExit":
				// Coming from top exit
				foreach (Transform child in level.transform) {
					if (child.tag == "BottomExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x, changePos.y + 15, changePos.z);
						break;
					}
				}
				break;

			case "BottomExit":
				// Coming from bottom exit
				foreach (Transform child in level.transform) {
					if (child.tag == "TopExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x, changePos.y - 15, changePos.z);
						break;
					}
				}
				break;

			case "LeftExit":
				// Coming from left exit
				foreach (Transform child in level.transform) {
					if (child.tag == "RightExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x - 15, changePos.y, changePos.z);
						break;
					}
				}
				break;

			case "RightExit":
				// Coming from right exit
				foreach (Transform child in level.transform) {
					if (child.tag == "LeftExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x + 15, changePos.y, changePos.z);
						break;
					}
				}
				break;

			default:
				Debug.LogError ("Change level came from non-exit, or tag is incorrect for exit");
				break;
			}
		}
	}
}
